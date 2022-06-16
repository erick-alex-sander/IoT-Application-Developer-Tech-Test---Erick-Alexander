// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var flag = 0;
var updateSensor;
//var initialLoadResponse = JSON.parse(startSimulation());
RefreshUI(0);

function changeColor(btn) {
    var classButton = document.getElementById(btn);
    if (flag === 0) {
        classButton.style.background = "red";
        classButton.textContent = "Stop";
        updateSensor = setInterval(function () {
            startSimulation();
            RefreshUI(1);
        }, 2000);
        flag = 1;
    }
    else {
        classButton.style.background = "green";
        classButton.textContent = "Start";
        clearInterval(updateSensor);
        flag = 0;
    }
}

function startSimulation() {
    /*
    fetch('/Home/StartSimulation', {
        method: 'POST',
        body: JSON.stringify({ id: "200" })
    }).then(response => {
        if (response.ok) {
            return response.json();
        }
        throw new Error('Request failed!');
    }, networkError => {
        console.log(networkError.message);
    }).then(jsonResponse => {
        console.log(jsonResponse);
        result = jsonResponse
    });
    */
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open("GET", '/Home/StartSimulation', false); // false for synchronous request
    xmlHttp.send(null);
    return xmlHttp.response;
    
};

function connfigCharts(labels, max, min, avg, med) {
    var data = {
        labels: labels,
        datasets: [{
            label: 'Max',
            backgroundColor: 'rgb(255, 99, 132)',
            borderColor: 'rgb(255, 99, 132)',
            data: max,
        },
        {
            label: 'Min',
            backgroundColor: 'rgb(100, 100, 0)',
            borderColor: 'rgb(100, 100, 0)',
            data: min,
        },
        {
            label: 'Average',
            backgroundColor: 'rgb(0, 0, 255)',
            borderColor: 'rgb(0, 0, 255)',
            data: avg,
        },
        {
            label: 'Median',
            backgroundColor: 'rgb(255, 255, 0)',
            borderColor: 'rgb(255, 255, 0)',
            data: med,
        }]
    };
    var config = {
        type: 'line',
        data: data,
        options: {}
    };

    return config;
};

function RefreshUI(isUpdate) {
    var initialLoadResponse = JSON.parse(startSimulation());
  
    var lookup = {};
    var items = initialLoadResponse;
    var labelDate = [];

    for (var item, i = 0; item = items[i++];) {
        var date = item.dateStamp;
        if (!(date in lookup)) {
            lookup[date] = 1;
            labelDate.push(date);
        }
    };

    var filterRoom1 = initialLoadResponse.filter(obj => obj.roomArea == "roomArea1");
    var filterRoom2 = initialLoadResponse.filter(obj => obj.roomArea == "roomArea2");
    var filterRoom3 = initialLoadResponse.filter(obj => obj.roomArea == "roomArea3");

    var room1 = {
        maxT: [],
        minT: [],
        avgT: [],
        medT: [],
        maxH: [],
        minH: [],
        avgH: [],
        medH: [],
    }

    var room2 = {
        maxT: [],
        minT: [],
        avgT: [],
        medT: [],
        maxH: [],
        minH: [],
        avgH: [],
        medH: [],
    }

    var room3 = {
        maxT: [],
        minT: [],
        avgT: [],
        medT: [],
        maxH: [],
        minH: [],
        avgH: [],
        medH: [],
    }

    for (var filter, i = 0; filter = filterRoom1[i++];) {
        room1.maxT.push(filter.maxT);
        room1.minT.push(filter.minT);
        room1.avgT.push(filter.avgT);
        room1.medT.push(filter.medianT);
        room1.maxH.push(filter.maxH);
        room1.minH.push(filter.minH);
        room1.avgH.push(filter.avgH);
        room1.medH.push(filter.medianH);
    }

    for (var filter, i = 0; filter = filterRoom2[i++];) {
        room2.maxT.push(filter.maxT);
        room2.minT.push(filter.minT);
        room2.avgT.push(filter.avgT);
        room2.medT.push(filter.medianT);
        room2.maxH.push(filter.maxH);
        room2.minH.push(filter.minH);
        room2.avgH.push(filter.avgH);
        room2.medH.push(filter.medianH);
    }

    for (var filter, i = 0; filter = filterRoom3[i++];) {
        room3.maxT.push(filter.maxT);
        room3.minT.push(filter.minT);
        room3.avgT.push(filter.avgT);
        room3.medT.push(filter.medianT);
        room3.maxH.push(filter.maxH);
        room3.minH.push(filter.minH);
        room3.avgH.push(filter.avgH);
        room3.medH.push(filter.medianH);
    }
    if (isUpdate === 0) {
        const Room1T = new Chart(
            document.getElementById("Room1T"),
            connfigCharts(labelDate, room1.maxT, room1.minT, room1.avgT, room1.medT)
        );

        const Room2T = new Chart(
            document.getElementById("Room2T"),
            connfigCharts(labelDate, room2.maxT, room2.minT, room2.avgT, room2.medT)
        );

        const Room3T = new Chart(
            document.getElementById("Room3T"),
            connfigCharts(labelDate, room3.maxT, room3.minT, room3.avgT, room3.medT)
        );

        const Room1H = new Chart(
            document.getElementById("Room1H"),
            connfigCharts(labelDate, room1.maxH, room1.minH, room1.avgH, room1.medH)
        );

        const Room2H = new Chart(
            document.getElementById("Room2H"),
            connfigCharts(labelDate, room2.maxH, room2.minH, room2.avgH, room2.medH)
        );

        const Room3H = new Chart(
            document.getElementById("Room3H"),
            connfigCharts(labelDate, room3.maxH, room3.minH, room3.avgH, room3.medH)
        );
    }
    else {
        const Room1T = Chart.getChart("Room1T");

        const Room2T = Chart.getChart("Room2T");

        const Room3T = Chart.getChart("Room3T");
            
        const Room1H = Chart.getChart("Room1H");

        const Room2H = Chart.getChart("Room2H");

        const Room3H = Chart.getChart("Room3H");

        Room1T.data.labels = labelDate;
        Room1T.data.datasets[0].data = room1.maxT;
        Room1T.data.datasets[1].data = room1.minT;
        Room1T.data.datasets[2].data = room1.avgT;
        Room1T.data.datasets[3].data = room1.medT;
        Room1T.update();

        Room2T.data.labels = labelDate;
        Room2T.data.datasets[0].data = room2.maxT;
        Room2T.data.datasets[1].data = room2.minT;
        Room2T.data.datasets[2].data = room2.avgT;
        Room2T.data.datasets[3].data = room2.medT;
        Room2T.update();

        Room3T.data.labels = labelDate;
        Room3T.data.datasets[0].data = room3.maxT;
        Room3T.data.datasets[1].data = room3.minT;
        Room3T.data.datasets[2].data = room3.avgT;
        Room3T.data.datasets[3].data = room3.medT;
        Room3T.update();

        Room1H.data.labels = labelDate;
        Room1H.data.datasets[0].data = room1.maxH;
        Room1H.data.datasets[1].data = room1.minH;
        Room1H.data.datasets[2].data = room1.avgH;
        Room1H.data.datasets[3].data = room1.medH;
        Room1H.update();

        Room2H.data.labels = labelDate;
        Room2H.data.datasets[0].data = room2.maxH;
        Room2H.data.datasets[1].data = room2.minH;
        Room2H.data.datasets[2].data = room2.avgH;
        Room2H.data.datasets[3].data = room2.medH;
        Room2H.update();

        Room3H.data.labels = labelDate;
        Room3H.data.datasets[0].data = room3.maxH;
        Room3H.data.datasets[1].data = room3.minH;
        Room3H.data.datasets[2].data = room3.avgH;
        Room3H.data.datasets[3].data = room3.medH;
        Room3H.update();

        console.log("chart updated");
    }
    
    var time = new Date();
    var dateString = time.getFullYear() + "-" + ("0" + (time.getMonth() + 1)).slice(-2) + "-" + ("0" + time.getDate()).slice(-2);

    var latestRoom1 = initialLoadResponse.filter(obj => obj.dateStamp == dateString);
    var latestRoom2 = initialLoadResponse.filter(obj => obj.dateStamp == dateString);
    var latestRoom3 = initialLoadResponse.filter(obj => obj.dateStamp == dateString);

    document.getElementById("maxT1").innerHTML = Math.floor(latestRoom1[0].maxT);
    document.getElementById("minT1").innerHTML = Math.floor(latestRoom1[0].minT);
    document.getElementById("medT1").innerHTML = Math.floor(latestRoom1[0].medianT);
    document.getElementById("avgT1").innerHTML = Math.floor(latestRoom1[0].avgT);

    document.getElementById("maxH1").innerHTML = Math.floor(latestRoom1[0].maxH);
    document.getElementById("minH1").innerHTML = Math.floor(latestRoom1[0].minH);
    document.getElementById("medH1").innerHTML = Math.floor(latestRoom1[0].medianH);
    document.getElementById("avgH1").innerHTML = Math.floor(latestRoom1[0].avgH);

    document.getElementById("maxT2").innerHTML = Math.floor(latestRoom2[0].maxT);
    document.getElementById("minT2").innerHTML = Math.floor(latestRoom2[0].minT);
    document.getElementById("medT2").innerHTML = Math.floor(latestRoom2[0].medianT);
    document.getElementById("avgT2").innerHTML = Math.floor(latestRoom2[0].avgT);

    document.getElementById("maxH2").innerHTML = Math.floor(latestRoom2[0].maxH);
    document.getElementById("minH2").innerHTML = Math.floor(latestRoom2[0].minH);
    document.getElementById("medH2").innerHTML = Math.floor(latestRoom2[0].medianH);
    document.getElementById("avgH2").innerHTML = Math.floor(latestRoom2[0].avgH);

    document.getElementById("maxT3").innerHTML = Math.floor(latestRoom3[0].maxT);
    document.getElementById("minT3").innerHTML = Math.floor(latestRoom3[0].minT);
    document.getElementById("medT3").innerHTML = Math.floor(latestRoom3[0].medianT);
    document.getElementById("avgT3").innerHTML = Math.floor(latestRoom3[0].avgT);

    document.getElementById("maxH3").innerHTML = Math.floor(latestRoom3[0].maxH);
    document.getElementById("minH3").innerHTML = Math.floor(latestRoom3[0].minH);
    document.getElementById("medH3").innerHTML = Math.floor(latestRoom3[0].medianH);
    document.getElementById("avgH3").innerHTML = Math.floor(latestRoom3[0].avgH);
};


