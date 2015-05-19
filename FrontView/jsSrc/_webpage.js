var _WebPageInfo = {
systemVirtualPath: '/',
NoImageText: 'no image',
ImageInfo: {prompt:"",exts:",jpg,png,jpeg,gif,"},
AudioInfo: {prompt:"",exts:",mp3,"},
VideoInfo: {prompt:"",exts:",wmv,"},
DigitalMediaInfo: {prompt:"",exts:",mp3,wmv,"},
ThreeDInfo: {prompt:"",exts:",3dp,"},
FlashInfo: {prompt:"",exts:",swf,"},
FileInfo: {prompt:"",exts:",doc,"},
ImageWidth:150,
ImageHeight:150,
UserPath:'/'
};

var ImageFilesSelector = Class.create();
ImageFilesSelector.prototype = {
  initialize: function() {
		this.WebPageInfo = _WebPageInfo;
  },
	getFileExt: function (path){
	  var tmp = path;
	  tmp = tmp.substring(tmp.lastIndexOf(".")+1);
	  return tmp.toUpperCase();
	},
	getFullName: function(path){
	  var tmp = path;
		var pos = -1;
		pos = tmp.lastIndexOf("\\");
		if (pos==-1){
		  pos = tmp.lastIndexOf("/");
		}
		if (pos==-1){
		  return path;
		}else{
		  return tmp.substring(pos+1);
		}
	},
	CheckExt: function (path,extList){
	  var ext = this.getFileExt(path);
	  extList = extList.toUpperCase();
	  var cExt = ("," + extList + ",").indexOf("," + ext + ",");
	  if (ext == "") return -1;
	  if (cExt==-1){
	    return 0;
	  }else{
	    return 1;
	  }
	}	
}