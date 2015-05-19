// JavaScript Document
var app;

require.config({
	paths: {
	    jQuery: "../js2/jquery.min",
		kendo: "../js2/kendo.mobile.min",
        
	},
    shim: {
        jQuery: {
            exports: "jQuery"
        },
        kendo: {
            exports: "kendo"
        }
    }
});

require(["jQuery", "app"], function($, application) {
    $(function() {
        app = application
        application.init();
    });
});