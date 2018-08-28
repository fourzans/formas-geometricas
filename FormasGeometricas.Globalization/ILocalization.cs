using System;

namespace FormasGeometricas.Globalization
{
    public interface ILocalization
    {
        void SetCurrentCulture(string culture);
        string LocalizeString(string key);
    }
}
