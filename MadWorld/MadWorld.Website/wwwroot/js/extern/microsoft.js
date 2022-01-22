var Microsoft;
(function (Microsoft) {
    var ApplicationInsights = /** @class */ (function () {
        function ApplicationInsights() {
        }
        ApplicationInsights.prototype.Init = function () {
            CreateApplicationInsight();
        };
        return ApplicationInsights;
    }());
    function Load() {
        window["ApplicationInsights"] = new ApplicationInsights();
    }
    Microsoft.Load = Load;
})(Microsoft || (Microsoft = {}));
Microsoft.Load();
//# sourceMappingURL=microsoft.js.map