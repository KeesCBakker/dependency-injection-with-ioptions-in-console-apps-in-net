#!/bin/bash

# Exit on errors
set -e

echo
echo "This script helps to generate a public / private key for JWT tokens."
echo

# Prompt user for service name
read -p "Enter the name of the service (lower-kebab-case): " SERVICE_NAME

echo 
echo "Generating key..."

# Variables
PRIVATE_KEY_FILE="private_key.pem"
PUBLIC_KEY_FILE="public_key.pem"

# Generate RSA private key
openssl genpkey -algorithm RSA -out $PRIVATE_KEY_FILE -pkeyopt rsa_keygen_bits:2048

# Extract public key
openssl rsa -pubout -in $PRIVATE_KEY_FILE -out $PUBLIC_KEY_FILE

# Read keys
PRIVATE_KEY=$(cat $PRIVATE_KEY_FILE)
PUBLIC_KEY=$(cat $PUBLIC_KEY_FILE)

# Encode keys with \n
PRIVATE_KEY_ENCODED=$(echo "$PRIVATE_KEY" | sed ':a;N;$!ba;s/\n/\\n/g')
PUBLIC_KEY_ENCODED=$(echo "$PUBLIC_KEY" | sed ':a;N;$!ba;s/\n/\\n/g')

# Output public and private keys with \n encoding
echo
echo "Private Key:"
echo "$PRIVATE_KEY_ENCODED"
echo

# Output public key in JSON format
echo "Public Key:"
echo "\"$SERVICE_NAME\": \"$PUBLIC_KEY_ENCODED\""
echo

# Ask user if they want to generate a sample token
read -p "Do you want to generate a sample token valid for 25 years? (yes/no): " GENERATE_TOKEN

if [[ "$GENERATE_TOKEN" == "yes" || "$GENERATE_TOKEN" == "y" ]]; then
    # Generate JWT token
    USER_NAME="tstusr"
    ISSUER="$SERVICE_NAME"
    AUDIENCE="our-service"
    EXP=$(($(date +%s) + 25 * 365 * 24 * 60 * 60)) # 25 years in seconds

    # Encode JWT header
    HEADER_BASE64=$(echo -n '{"alg":"RS256","typ":"JWT"}' | openssl base64 -e -A | tr '+/' '-_' | tr -d '=')

    # Encode JWT payload
    PAYLOAD=$(cat <<EOF
{
  "iss": "$ISSUER",
  "aud": "$AUDIENCE",
  "username": "$USER_NAME",
  "iat": $(date +%s),
  "exp": $EXP
}
EOF
    )

    PAYLOAD_BASE64=$(echo -n "$PAYLOAD" | openssl base64 -e -A | tr '+/' '-_' | tr -d '=')

    # Create unsigned token
    UNSIGNED_TOKEN="$HEADER_BASE64.$PAYLOAD_BASE64"

    # Sign the token
    SIGNATURE=$(echo -n "$UNSIGNED_TOKEN" | openssl dgst -sha256 -sign $PRIVATE_KEY_FILE | openssl base64 -e -A | tr '+/' '-_' | tr -d '=')

    # Combine header, payload, and signature to form the JWT
    JWT="$UNSIGNED_TOKEN.$SIGNATURE"

    # Output the JWT
    echo "Generated JWT:"
    echo "$JWT"
    echo

    # Output the payload
    echo "JWT Payload:"
    echo "$PAYLOAD"
fi

# Cleanup
rm -f $PRIVATE_KEY_FILE $PUBLIC_KEY_FILE