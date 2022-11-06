console.log('Javascript File loaded which will load an iFrame - loadscript.js');
var scriptFrame = document.createElement('iframe');
scriptFrame.src = 'javascript:""';
scriptFrame.id = 'frame4';
scriptFrame.name = 'frame4'
scriptFrame.style.cssText = 'position:absolute; width:0; height:0; border:none; left: -1000px;' + ' top: -1000px;';
scriptFrame.tabIndex = -1;
document.body.appendChild(scriptFrame);
frameDoc = scriptFrame.contentDocument;
if (!frameDoc) {
    frameDoc = scriptFrame.contentWindow.document;
}
frameDoc.open();
var doctype = document.compatMode == 'CSS1Compat' ? '<!doctype html>' : '';
frameDoc.write(doctype + '<html><head><\/head><body><\/body><\/html>');
frameDoc.close();