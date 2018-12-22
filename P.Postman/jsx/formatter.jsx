var targetDoc = app.activeDocument;
var pgs = targetDoc.pages;

var dataFile = new File("C:\\Users\\cdrie\\systems\\pesusich\\P.Postman\\sanitized.txt")

dataFile.open("r");
var data = dataFile.read().split("\n");

//$.writeln(data[1])

//var testFrame = pgs[0].textFrames[0];
//testFrame.contents = data[0] + "\n" + data[1] + "\n" + data[2];
//$.writeln(testFrame.contents);

for (i = 0; i < 121; i++) {
    var activePgIndex = Math.floor (i / 30);
    var activePg = pgs[activePgIndex];
    
    var frames = activePg.textFrames;
    var activeFrameIndex = i % 30;
    var activeFrame = frames[activeFrameIndex];
    
    var baseIndex = i * 3;
    
    activeFrame.contents = data[baseIndex] + "\n" + data[baseIndex + 1] + "\n" + data[baseIndex + 2];
    }

