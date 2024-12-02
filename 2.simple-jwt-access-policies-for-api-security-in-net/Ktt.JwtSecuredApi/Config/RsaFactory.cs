using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

public class RsaFactory : IDisposable
{
    private readonly ConcurrentDictionary<string, RSA> _keys = new ConcurrentDictionary<string, RSA>();

    public RsaFactory(JwtOptions jwtOptions)
    {
        var trustedServices = jwtOptions.TrustedServices;
        if (trustedServices.Count == 0)
        {
            throw new InvalidOperationException("TrustedServices section is missing or empty in configuration.");
        }

        foreach (var service in trustedServices.Keys)
        {
            var publicKeyPem = trustedServices[service];
            var rsa = RSA.Create();
            rsa.ImportFromPem(publicKeyPem);
            _keys.TryAdd(service, rsa);
        }
    }

    public bool TryGetRsa(string issuer, [MaybeNullWhen(false)] out RSA rsa)
    {
        return _keys.TryGetValue(issuer, out rsa);
    }

    void IDisposable.Dispose()
    {
        foreach (var key in _keys.Values)
        {
            key.Dispose();
        }

        _keys.Clear();
    }
}