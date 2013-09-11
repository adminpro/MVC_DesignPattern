var prependZero = function (v) {
    v = v.toString();
    return (v.length == 1) ? "0" + v : v;
};
var dateDeserialize = function (dateStr) {
    var dt = new Date(parseInt(dateStr.substr(6)));
    return prependZero((dt.getMonth() + 1))
                + "/" + prependZero(dt.getDate())
                + "/" + dt.getFullYear()
                + " " + prependZero(dt.getHours())
                + ":" + prependZero(dt.getMinutes())
                + ":" + prependZero(dt.getSeconds());
};
