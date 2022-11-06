console.log(`********************   AddScriptToExecuteOnDocumentCreatedAsync SCRIPT LOADED   ******************************************`);
if (!window.frameElement) {
    console.log('Window frameElement is nothing. This is the Top Doc.');
} else {
    if (window.frameElement.src) console.log('Frame SRC: ' + window.frameElement.src); 
    if (window.name) console.log('Frame name ' + window.name);
    if (window.frameElement.id) console.log('Frame ID: ' + window.frameElement.id);
    window.parent.PrintFrameCountA();
}

 function PrintFrameCountA(){
     console.log(`TOP DOC Frame Count ${window.frames.length}`);
     //const iframes = document.getElementsByTagName("iframe")
     //for (let i = 0; i < iframes.length; i++) { console.log(iframes[i].id); }
     console.log(`**************************************************************`);
 }