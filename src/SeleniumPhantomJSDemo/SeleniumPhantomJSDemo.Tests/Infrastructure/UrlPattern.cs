using System;
using System.Linq;
using System.Text.RegularExpressions;
using SeleniumPhantomJSDemo.Tests.Extensions;

namespace SeleniumPhantomJSDemo.Tests.Infrastructure
{
    public class UrlPattern
    {
        private readonly string _relativeUrlTemplate;
        private readonly string _relativeUrlPattern;
        private readonly ParameterType[] _parameterTypes;

        public UrlPattern(string relativeUrlTemplate, params ParameterType[] parameterTypes)
        {
            _relativeUrlTemplate = relativeUrlTemplate;
            _parameterTypes = parameterTypes;

            if (parameterTypes.Any())
            {
                _relativeUrlPattern = string.Format(relativeUrlTemplate, parameterTypes.Select(x => x.RegexPattern).ToArray());
            }
            else
            {
                _relativeUrlPattern = _relativeUrlTemplate;
            }
        }

        public string ToAbsoluteUrl(params object[] args)
        {
            return string.Format(_relativeUrlTemplate, args).ToAbsoluteUrl();
        }

        public int GetIntParameter(string url)
        {
            var regex = new Regex(_relativeUrlPattern);
            var match = regex.Match(url);
            var matchedId = match.Groups[1].Value;
            return int.Parse(matchedId);
        }

        public bool IsMatch(string url)
        {
            return new Regex(_relativeUrlPattern.ToAbsoluteUrl(), RegexOptions.IgnoreCase).IsMatch(url);
        }
    }
}