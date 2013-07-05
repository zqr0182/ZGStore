$(function () {
    var countries = $("#CountryId");

    var statesContainer = $("#states");
    var states = $("#StateId");
    var selectedState = $("#State");

    var provincesContainer = $("#provinces");
    var provinces = $("#ProvinceId");
    var selectedProvince = $("#Province");

    statesContainer.hide();
    provincesContainer.hide();

    countries.change(function () {
        var selectedCountry = countries.find(":selected").text();
        if (selectedCountry == "UNITED STATES") {
            statesContainer.show();
            provincesContainer.hide();
            provinces.val("");
            selectedProvince.val("");
        }
        else if (selectedCountry == "CANADA") {
            provincesContainer.show();
            statesContainer.hide();
            states.val("");
            selectedState.val("");
        }
        else {
            statesContainer.hide();
            states.val("");
            selectedState.val("");

            provincesContainer.hide();
            provinces.val("");
            selectedProvince.val("");
        }
    });

    states.change(function () {
        selectedState.val(states.find(":selected").text());
    });

    provinces.change(function () {
        selectedProvince.val(provinces.find(":selected").text());
    });
});