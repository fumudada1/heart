/*
Copyright (c) 2003-2010, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
    //config.filebrowserBrowseUrl = location.hash + '/lts/webEditor/ckfinder/ckfinder.html';
    //config.filebrowserImageBrowseUrl = location.hash + '/lts/webEditor/ckfinder/ckfinder.html?Type=Images';
    //config.filebrowserFlashBrowseUrl = location.hash + '/lts/webEditor/ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = location.hash + '/webEditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = location.hash + '/webEditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = location.hash + '/webEditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
    // This is actually the default value.
 config.toolbar_Full =
  [
     ['Source','-','NewPage'],
     ['Cut','Copy','Paste','-','Print'],
     ['Undo','Redo','-','Find','Replace','-','SelectAll','RemoveFormat'],
     '/',
     ['Bold','Italic','Underline','Strike'],
     ['NumberedList','BulletedList','-','Outdent','Indent'],
     ['JustifyLeft','JustifyCenter','JustifyRight','JustifyBlock'],
     ['Link','Unlink','Anchor'],
     ['Image','Table','HorizontalRule'],
     
     ['Format','Font','FontSize'],
     ['TextColor','BGColor']
    
	 ];
	config.toolbar = 'Full';
config.enterMode = CKEDITOR.ENTER_BR;
	};
	
	


	
	CKEDITOR.config.font_names =
	'細明體/細明體_HKSCS;' +
	'新細明體/新細明體-ExtB;' +
	'Arial/Arial, Helvetica, sans-serif;' +
	'Comic Sans MS/Comic Sans MS, cursive;' +
	'Courier New/Courier New, Courier, monospace;' +
	'Georgia/Georgia, serif;' +
	'Lucida Sans Unicode/Lucida Sans Unicode, Lucida Grande, sans-serif;' +
	'Tahoma/Tahoma, Geneva, sans-serif;' +
	'Times New Roman/Times New Roman, Times, serif;' +
	'Trebuchet MS/Trebuchet MS, Helvetica, sans-serif;' +
	'Verdana/Verdana, Geneva, sans-serif';
