# Dependency injection (with IOptions) in Console Apps in .NET

Services can use their private key to communicate with our service.
We can configure the access for each issuer using standard .NET claims.

<a href="https://keestalkstech.com/2024/11/simple-jwt-access-policies-for-api-security-in-net/">Simple JWT Access Policies for API security in .NET</a>

## Tokens

We have 2 JWT tokens that should last 25 years:

### `service-1`

May access secured endpoint `/api/users`.

```txt
eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.ewogICJpc3MiOiAic2VydmljZS0xIiwKICAiYXVkIjogIm91ci1zZXJ2aWNlIiwKICAidXNlcm5hbWUiOiAidHN0dXNyIiwKICAiaWF0IjogMTczMjk3MjMwNSwKICAiZXhwIjogMjUyMTM3MjMwNQp9.wWJh41loGBZKyDYBr-U9EJReEPsO6PA9z-EYE5rXO44e6XPjcsAMigoVcrR2w0T8-6is5ICJy2fukwOPDMLk9D2bs8k7TSVEuqzwh80tlBMPV5dRdkq3r1dg_KRZgkzG4ylLiK9hBoqvmL5HKE7oqo3AvHoUc1LOD5Y6BzeqasxVfOpIcjIa2nNXRLeRE7KfffWcbKXOm6HpYL2n_8j4pVbCePo1D8jtg55EQATcr1QQpvERzr9p-_PHqaC8woookSXqclTrwt-cQPj4RsvCQUXpKNzggXYytzHAaTlRAInlZP34tiDenb1Qz3wTtsqCXsh92BFZYABoJjIDGxcI5Q

JWT Payload:
{
  "iss": "service-1",
  "aud": "our-service",
  "username": "tstusr",
  "iat": 1732972305,
  "exp": 2521372305
}
```

### `service-2`

May access secured endpoints `/api/orders` and `/api/users`.


```txt
eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.ewogICJpc3MiOiAic2VydmljZS0yIiwKICAiYXVkIjogIm91ci1zZXJ2aWNlIiwKICAidXNlcm5hbWUiOiAidHN0dXNyIiwKICAiaWF0IjogMTczMjk3MjM2NywKICAiZXhwIjogMjUyMTM3MjM2Nwp9.VGl-UElY0x7rLxIXlsYY6Cbd-0CbZIpzGQ1mgF2Ux-uBkyr4DYopFmJ37TUgcJ0xi-r5Q8UuKsCRWnm6DChpC8-189U49YXVu2cLdI5CTVdui2HvsUHvo9mSB7Rb1aPpMbQOFG-RZr6JfQXwBG5VJlk7CW1cF44JWvilVksZltm6zH_6Megt1Rbx7YXKDHV-gKXWawaevhGKBVRgGsPh1qF3GgqL6I_Tf-ZMt3_kTzkMGom6r7VZlO3Ze4Y8u1odVm1ZAHFjVwZy2UvNyPdQHW92COR7YKMJStVqKlCkQ6JDwgtnCMvPIu9tgr9WYtQaAwh6P3EbUuyp56C0lvNOPQ

JWT Payload:
{
  "iss": "service-2",
  "aud": "our-service",
  "username": "tstusr",
  "iat": 1732972367,
  "exp": 2521372367
}
```

## Features

- Support for .NET 8
- Support for IOption data validation validation on startup
- Script <a href="generate_keys.sh">generate_keys.sh</a> will generate a new public/private key pair. In Windows you can use WSL to execute the file.