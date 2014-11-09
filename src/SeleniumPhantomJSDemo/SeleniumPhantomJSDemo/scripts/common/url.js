spd.url.create = function (url) {

    function stripLeadingSlash(s) {
        var hasLeadingSlash = s[0] == '/';

        if (hasLeadingSlash) {
            s = s.substr(1);
        }

        return s;
    }

    var startsWithBaseUrlRegex = new RegExp("^" + spd.url.baseUrl, "i");

    if (startsWithBaseUrlRegex.test(url)) {
        return url;
    }

    return spd.url.baseUrl + stripLeadingSlash(url);
};