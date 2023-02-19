const fs = require('fs');
const readline = require('readline');
const world = require('./World.js');






function handleInputLine(l) {
    var points = l.split(" -> ");

    for (i = 0; i < points.length - 1; i++) {
        var start = points[i].split(',');
        var end = points[i+1].split(',');
        var segmentpoints = handleSegment(
            {x: parseInt(start[0]), y: parseInt(start[1])},
            {x: parseInt(end[0]), y: parseInt(end[1])});
    }
}

// won't work for diagnals only vertical or horizontal
function handleSegment(p1, p2) {
    var magnitude = Math.abs((p2.x - p1.x) + (p2.y - p1.y));
    var step = {x: (p2.x - p1.x)/magnitude, y: (p2.y - p1.y)/magnitude};

    var p = {x: p1.x, y: p1.y};
    world.set(p1.x, p1.y, "#");
    while(p.x != p2.x || p.y != p2.y) {
        p.x += step.x;
        p.y += step.y;
        world.set(p.x, p.y, "#");
    }
}

function handleInputEnd() {
    world.dump();
    world.minNonEmptyY(500);
    world.minNonEmptyY(501);
    world.minNonEmptyY(502);
}

var linereader = readline.createInterface({
    input: fs.createReadStream('input-example.txt')
});
linereader.on('line', handleInputLine);
linereader.on('close', handleInputEnd);
