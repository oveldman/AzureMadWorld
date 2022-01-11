"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DocumentManager = void 0;
var DocumentManager = /** @class */ (function () {
    function DocumentManager() {
    }
    DocumentManager.GetElementByID = function (name) {
        return document.getElementById(name);
    };
    return DocumentManager;
}());
exports.DocumentManager = DocumentManager;
//# sourceMappingURL=documenthandler.js.map