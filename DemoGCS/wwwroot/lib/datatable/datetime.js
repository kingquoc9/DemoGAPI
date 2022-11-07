/**
 * This plug-in for DataTables represents the ultimate option in extensibility
 * for sorting date / time strings correctly. It uses
 * [Moment.js](http://momentjs.com) to create automatic type detection and
 * sorting plug-ins for DataTables based on a given format. This way, DataTables
 * will automatically detect your temporal information and sort it correctly.
 *
 * For usage instructions, please see the DataTables blog
 * post that [introduces it](//datatables.net/blog/2014-12-18).
 *
 * @name Ultimate Date / Time sorting
 * @summary Sort date and time in any format using Moment.js
 * @author [Allan Jardine](//datatables.net)
 * @depends DataTables 1.10+, Moment.js 1.7+
 *
 * @example
 *    $.fn.dataTable.moment( 'HH:mm MMM D, YY' );
 *    $.fn.dataTable.moment( 'dddd, MMMM Do, YYYY' );
 *
 *    $('#example').DataTable();
 */

(function (factory) {
	if (typeof define === "function" && define.amd) {
		define(["jquery", "moment", "datatables.net"], factory);
	} else {
		factory(jQuery, moment);
	}
}(function ($, moment) {

	function strip(d) {
		if (typeof d === 'string') {
			// Strip HTML tags and newline characters if possible
			d = d.replace(/(<.*?>)|(\r?\n|\r)/g, '');

			// Strip out surrounding white space
			d = d.trim();
		}

		return d;
	}

	$.fn.dataTable.moment = function (format, locale, reverseEmpties) {
		var types = $.fn.dataTable.ext.type;

		// Add type detection
		types.detect.unshift(function (d) {
			d = strip(d);

			// Null and empty values are acceptable
			if (d === '' || d === null) {
				return 'moment-' + format;
			}

			return moment(d, format, locale, true).isValid() ?
				'moment-' + format :
				null;
		});

		// Add sorting method - use an integer for the sorting
		types.order['moment-' + format + '-pre'] = function (d) {
			d = strip(d);

			return !moment(d, format, locale, true).isValid() ?
				(reverseEmpties ? -Infinity : Infinity) :
				parseInt(moment(d, format, locale, true).format('x'), 10);
		};
	};
	

}));

/**
 * Date / time formats often from back from server APIs in a format that you
 * don't wish to display to your end users (ISO8601 for example). This rendering
 * helper can be used to transform any source date / time format into something
 * which can be easily understood by your users when reading the table, and also
 * by DataTables for sorting the table.
 *
 * The [MomentJS library](http://momentjs.com/) is used to accomplish this and
 * you simply need to tell it which format to transfer from, to and specify a
 * locale if required.
 *
 * This function should be used with the `dt-init columns.render` configuration
 * option of DataTables.
 *
 * It accepts one, two or three parameters:
 *
 * * `$.fn.dataTable.render.moment( to );`
 * * `$.fn.dataTable.render.moment( from, to );`
 * * `$.fn.dataTable.render.moment( from, to, locale );`
 *
 * Where:
 *
 * * `to` - the format that will be displayed to the end user
 * * `from` - the format that is supplied in the data (the default is ISO8601 -
 *   `YYYY-MM-DD`)
 * * `locale` - the locale which MomentJS should use - the default is `en`
 *   (English).
 *
 *  @name datetime
 *  @summary Convert date / time source data into one suitable for display
 *  @author [Allan Jardine](http://datatables.net)
 *  @requires DataTables 1.10+, Moment.js 1.7+
 *
 *  @example
 *    // Convert ISO8601 dates into a simple human readable format
 *    $('#example').DataTable( {
 *      columnDefs: [ {
 *        targets: 1,
 *        render: $.fn.dataTable.render.moment( 'Do MMM YYYY' )
 *      } ]
 *    } );
 *
 *  @example
 *    // Specify a source format - in this case a unix timestamp
 *    $('#example').DataTable( {
 *      columnDefs: [ {
 *        targets: 2,
 *        render: $.fn.dataTable.render.moment( 'X', 'Do MMM YY' )
 *      } ]
 *    } );
 *
 *  @example
 *    // Specify a source format and locale
 *    $('#example').DataTable( {
 *      columnDefs: [ {
 *        targets: 2,
 *        render: $.fn.dataTable.render.moment( 'YYYY/MM/DD', 'Do MMM YY', 'fr' )
 *      } ]
 *    } );
 */


// UMD
(function (factory) {
	"use strict";

	if (typeof define === 'function' && define.amd) {
		// AMD
		define(['jquery'], function ($) {
			return factory($, window, document);
		});
	}
	else if (typeof exports === 'object') {
		// CommonJS
		module.exports = function (root, $) {
			if (!root) {
				root = window;
			}

			if (!$) {
				$ = typeof window !== 'undefined' ?
					require('jquery') :
					require('jquery')(root);
			}

			return factory($, root, root.document);
		};
	}
	else {
		// Browser
		factory(jQuery, window, document);
	}
}
	(function ($, window, document) {


		$.fn.dataTable.render.moment = function (from, to, locale) {
			// Argument shifting
			if (arguments.length === 1) {
				locale = 'en';
				to = from;
				from = 'YYYY-MM-DD';
			}
			else if (arguments.length === 2) {
				locale = 'en';
			}

			return function (d, type, row) {
				if (!d) {
					return type === 'sort' || type === 'type' ? 0 : d;
				}

				var m = window.moment(d, from, locale, true);

				// Order and type get a number value from Moment, everything else
				// sees the rendered value
				return m.format(type === 'sort' || type === 'type' ? 'x' : to);
			};
		};


	}));