var vmCategory = {
    DataSource: ko.observableArray([]),
    SelectedItem: null,
    SelectItem: function (trackingMap) {
        this.SelectedItem = trackingMap;
    },
    NewTrackingMap: function () {
        var newItem = {
            Id: 0,
            Name:'New category',
            Url: '/New-category',
            Order:0,
            Status: false
        };
        this.DataSource.push(newItem);
        return newItem;
    },
    Create: function () {
        this.IsNew = true;
        this.SelectItem(this.NewTrackingMap);
    },
    Edit: function (trackingMap) {
        this.IsNew = false;
        this.SelectItem(trackingMap);
    },
    Save: function () {
        //Case add
        var currentItem = this.SelectedItem;
        if (trackingMap.TrackingMapId == 0) {
            $.ajax({
                type: 'POST',
                url: '/api/TrackingMapAPI/Create',
                data: { trackingMap: currentItem }
            }).done(function (data) {
                this.LoadTrackingMap;
            });
        }
        else {
            $.ajax({
                type: 'PUT',
                url: '/api/TrackingMapAPI/Edit',
                data: { trackingMapId: currentItem.trackingMapId, currentItem: trackingMap }
            }).done(function (data) {
                this.LoadTrackingMap;
            });
        }
    },
    Delete: function (trackingMapId) {
        $.ajax({
            type: 'POST',
            url: '/api/TrackingMapAPI/Delete',
            data: { trackingMapId: trackingMapId }
        }).done(function (data) {
            this.LoadTrackingMap;
        });
    },
    LoadTrackingMap: function () {
        $.ajax({
            type: 'GET',
            url: '/api/TrackingMapAPI/GetAll',
            data: { skip: 0, take: 10 }
        }).done(function (data) {
            this.DataSource(data);
        });
    },
    IsNew: false
}