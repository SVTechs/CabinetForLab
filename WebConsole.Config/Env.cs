using System;

namespace WebConsole.Config
{
    public class Env
    {
        public static string UnitName = "XX公司";
        public static string UnitNameFull = "XX公司";
        public static string AppName = "XX管理系统";

        public static string EncSeed = "BasicSystem";
        public static string AppRoot = "/";

        public static bool EnableCopyright = false;

        public static string PresetPrivateKey = @"MIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQC5HELN3FfwxIhIHhoLOo1JPm9ZNeWGx1XnNHAfjc3Ky2LV7J45lg+6XT18Uy4iOc/MR6rdpC/yjVmovVQM+ZTDr9HjNW257bGd1kDTHazs90B9Yc36uY8BwAB85pImTfJpKPJulPjFD9bCKyrH9GCqu4FNoIZcltVU3B/HGU+AydQCOffVwtwz570UrkLDjt+h/4ZMYalxOJ7wgz6PRe5aMA6x52Z46/Gj2MbxWdRBcyMMAy/E6r/39KgjKB2b2VJBV10PiHGpsYJKrU8sdpaMXWguJs2LfZlwlyFcFI+1TpBWI4I85gC+FY0UEJbWFvwRcmBMD+TQYA1cXbyFW7yJAgInEQKCAQA0rVm8fTZiuHpU+hqBzOFTojasUOsHGYWeYVia/LWvsCnlsR9HzkvkgSDHW0YIDN4wZ71iRPENWViCflF2I3F4KrZkFYBQ6d7kZfo7aXwVDRlxRBjg4fIfNwWxiDy8piQ37rosoCQvYASlbR6HE3LfaoZFZP8zDL5VYLYU7IEpLajwUaD4byL/cEiZVraLtLXTrkqfLY3Stjiv27CtlGqWmGGdxfiB1ymTwH5GxCZjx5kJtQsrt3naIOQgf8kM8NtRktnxgQppNLuiaaAAH4aKsasOC7BkjLi5xArmsAebqWs2HPuBAgjIINCbnJicx7VW7Qegc+lgOLZlpEdh52ZpAoGBAO9tjZPXZGDpvm0jfXuJqZ2/cspLmlOGmy96cjbp3p+KwNAem4kUm2DkF+bbXtE1PUY8+Q1wx260IZwP0G/PssHbfTm/AG9o694TsWER15SMSvwFXdt8I8GgNuR8XgjGvk5irAr98xcUhyvd8ZqOqQ9U0Si2Lw6lP84zdQwEIZQrAoGBAMXsQAFE8SCZCsXC66UZK7c94o164s3GNQa1YPNkLUf44e6+Dj+As/68DZn/zODjjLQu6ChRuO2pEH05g+yk4eUh3kehg61dX+Y4bzZGzdGw4+5F9Gxj5PQB67C+DyRqgKTGOHqKydpGOXhHSNgd+hQFDPysEWMyf9COe8dLGVQbAoGARh8WKdbf9s5TFS/eYf+XgJKBYPOPSXs6bVucs6Z0eLOoDGtcUXyaPmVBip5X5cdhwh8QwPkzNwzMLdV7JPhHXyVNX/UAYih7I/YM9toRchplDo0uH32J0bqU7Vg1CPGwRgFAvxq80HEWDbErNz+QgTn2qKgIZ/3D0i+7jp2cOdsCgYEAiRZjKVlFNFKN7LqWNh8T1cvsKsEPGi9pZ8+d+IVnn+tNXb0ayd50h7YjLACG991R5H7keqMJn0LTaegtEbHC1RlAAif3c1EOdcJwZ47oJc5TYh+pMVlVx+c4jmipPkm3OW3uFnhLDD2XiceoDHywQgirQeL4aO1tcQTfs/cemRcCgYAkXrn8Rkw/k2dm2RiHLJZW38Nel8WHEz/iURDW8occMLA774iE+QJYNKzVZM3asOnwVkqF0Qc4aKKMi7nDERriNNyw1fG1UhbHg8chVm8QVEHO+nOOlabBciPj1+2/Ee/jJc8yroNtX5Opi7geNhfEjY4qmK64dYSU4A01OaT/SA==";

        public static string PresetPublicKey =
            @"MIIBITANBgkqhkiG9w0BAQEFAAOCAQ4AMIIBCQKCAQEAuRxCzdxX8MSISB4aCzqNST5vWTXlhsdV5zRwH43Nysti1eyeOZYPul09fFMuIjnPzEeq3aQv8o1ZqL1UDPmUw6/R4zVtue2xndZA0x2s7PdAfWHN+rmPAcAAfOaSJk3yaSjybpT4xQ/Wwisqx/RgqruBTaCGXJbVVNwfxxlPgMnUAjn31cLcM+e9FK5Cw47fof+GTGGpcTie8IM+j0XuWjAOsedmeOvxo9jG8VnUQXMjDAMvxOq/9/SoIygdm9lSQVddD4hxqbGCSq1PLHaWjF1oLibNi32ZcJchXBSPtU6QViOCPOYAvhWNFBCW1hb8EXJgTA/k0GANXF28hVu8iQICJxE=";

        public static string AsposeLicense = @"<License>
<Data>
<LicensedTo>The World Bank</LicensedTo>
<EmailTo>kkumar3@worldbankgroup.org</EmailTo>
<LicenseType>Developer Small Business</LicenseType>
<LicenseNote>1 Developer And 1 Deployment Location</LicenseNote>
<OrderID>210316185957</OrderID>
<UserID>744916</UserID>
<OEM>This is not a redistributable license</OEM>
<Products>
<Product>Aspose.Total for .NET</Product>
</Products>
<EditionType>Professional</EditionType>
<SerialNumber>03fb199a-5c8a-48db-992e-d084ff066d0c</SerialNumber>
<SubscriptionExpiry>20220516</SubscriptionExpiry>
<LicenseVersion>3.0</LicenseVersion>
<LicenseInstructions>https://purchase.aspose.com/policies/use-license</LicenseInstructions>
</Data>
<Signature>WnBX6rNtzBrSLWzAtYj8Kdt1KIB92Qk/lDlSf2S5LTHXgdq/PCcjXuNFjt4BnFfp4VKsulJ8VxQ1jB0nc4GYVqfKzMxHQdiqneM752Z29OngrUn4bM+sYzYeRLOT8JqlOQ7NkDU4mI6gUrCwqr7gQV1l2IZBq5s3LAG0TcCVgpA=</Signature>
</License>";

        public static DateTime MinTime = DateTime.Parse("1900-01-01 00:00:00"), MaxTime = DateTime.Parse("2099-12-31 23:59:59");
    }
}
