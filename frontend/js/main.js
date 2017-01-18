$( function() {
    $( "#accordion" ).accordion(
        {
            collapsible: true,
            animate: 150,
            heightStyle: "content"
        }
    );
} );

$( function() {
    $( "#slider" ).slider({
      range: true,
      min: 0,
      max: 500,
      values: [ 75, 300 ],
      slide: function( event, ui ) {
        $( "#amount" ).val( "$" + ui.values[ 0 ] + " - $" + ui.values[ 1 ] );
      }
    });
    $( "#amount" ).val( "$" + $( "#slider-range" ).slider( "values", 0 ) +
      " - $" + $( "#slider-range" ).slider( "values", 1 ) );
    $('#accordion').removeClass('ui-widget');
    $('#accordion').removeClass('ui-helper-reset');
    $('#accordion').removeClass('ui-accordion');
  } );
