angular.module("spd").factory("page", function() {

    var title = 'Selenium & PhantomJS Demo';
    return {
        title: function() { return title; },
        setTitle: function(newTitle) {
            title = newTitle + " - Selenium & PhantomJS Demo";
        }
    };
});