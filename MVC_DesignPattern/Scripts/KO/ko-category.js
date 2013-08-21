var vmCategory = {
    DataSource: ko.observableArray([]),
    SelectedItem: ko.observable(null),
    SelectItem: function (category) {
        vmCategory.SelectedItem(category);
        $('.box-model').show();
    },
    NewItem: function () {
        var newItem = {
            Id: 0,
            Name:'New category',
            Url: '/New-category',
            Order:0,
            Status: false
        };
        vmCategory.DataSource.push(newItem);
        return newItem;
    },
    Create: function () {
        vmCategory.IsNew = true;
        vmCategory.SelectItem(this.NewItem);
    },
    Edit: function (category) {
        vmCategory.IsNew = false;
        vmCategory.SelectItem(category);
    },
    Save: function () {
        //Case add
        var currentItem = this.SelectedItem;
        if (category.categoryId == 0) {
            $.ajax({
                type: 'POST',
                url: '/api/CategoryApi/Create',
                data: { category: currentItem }
            }).done(function (data) {
                vmCategory.Load();
                vmCategory.IsNew = false;
            });
        }
        else {
            $.ajax({
                type: 'PUT',
                url: '/api/CategoryApi/Edit',
                data: { categoryId: currentItem.Id, currentItem: category }
            }).done(function (data) {
                vmCategory.Load();
            });
        }
    },
    Delete: function (categoryId) {
        $.ajax({
            type: 'POST',
            url: '/api/CategoryApi/Delete',
            data: { categoryId: categoryId }
        }).done(function (data) {
            vmCategory.Load();
        });
    },
    Load: function () {
        $.ajax({
            type: 'GET',
            url: '/api/CategoryApi/GetAll',
            data: { pIndex: 0, pSize: 10 }
        }).done(function (data) {
            $.each(data, function (index) {
                vmCategory.DataSource.push(toKoObserable(data[index]));
            });
            ko.applyBindings(vmCategory);
        });
    },
    IsNew: false,
    IsShow: false
}
function toKoObserable(category) {
    return {
        Id: ko.observable(category.Id),
        Name: ko.observable(category.Name),
        Url: ko.observable(category.Url),
        Order: ko.observable(category.Order),
        Status: ko.observable(category.Status)
    };
}