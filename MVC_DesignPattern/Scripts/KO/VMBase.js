(function (ko, undefined) {
    ko.BaseViewModel = function (opts) {
        var self = this;
        self.items = ko.observable([]);
        self.newItem = {};
        self.dirtyItems = ko.computed(function () {
            return self.items().filter(function (item) {
                return item.dirtyFlag.isDirty();
            });
        });
        self.isDirty = ko.computed(function () {
            return self.dirtyItems().length > 0;
        });
        self.load = function () { }
    };
} (ko));