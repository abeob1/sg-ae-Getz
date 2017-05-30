
function getParameterByNameOnly(name)
{
  name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
  var regexS = "[\\?&]" + name + "=([^&#]*)";
  var regex = new RegExp(regexS);
  var results = regex.exec(window.location.search);
  if(results == null)
    return "";
  else
    return decodeURIComponent(results[1].replace(/\+/g, " "));
}


function getParameterByName(name, qs)
{
  name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
  var regexS = "[\\?&]" + name + "=([^&#]*)";
  var regex = new RegExp(regexS);
  var results = regex.exec(qs);
  if(results == null)
    return "";
  else
    return decodeURIComponent(results[1].replace(/\+/g, " "));
}

function ResizeScreenImage () {

        var max_size = $(document).width()-20;
        $("img").each(function(i) {
          if ($(this).height() > $(this).width()) {
            var h = max_size;
            var w = Math.ceil($(this).width() / $(this).height() * max_size);
          } else {
            var w = max_size;
            var h = Math.ceil($(this).height() / $(this).width() * max_size);
          }
          $(this).css({ height: h, width: w });
        });   

}

function ResizeScreenImageFullSize (img_id) {

        var max_size = $(document).width() + 5;
        $("#" + img_id).each(function(i) {
        	
          var w = max_size;
          var h = Math.ceil($(this).height() / $(this).width() * max_size);
          $(this).css({ height: h, width: w });
          
          
        });   

		
}
