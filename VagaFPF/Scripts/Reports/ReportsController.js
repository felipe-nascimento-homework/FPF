


$.ajax({
    type: "POST",
    url: "/Reports/NewChart",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (chData) {
        var aData = chData;
        var aLabels = aData[0];
        var aDatasets1 = aData[1];
        var dataT = {
            labels: aLabels,
            datasets: [{
                label: "Dados dos funcionários por departamento",
                data: aDatasets1,
                fill: false,
                backgroundColor: ["rgba(54, 162, 235, 0.2)", "rgba(255, 99, 132, 0.2)", "rgba(255, 159, 64, 0.2)", "rgba(255, 205, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(201, 203, 207, 0.2)"],
                borderColor: ["rgb(54, 162, 235)", "rgb(255, 99, 132)", "rgb(255, 159, 64)", "rgb(255, 205, 86)", "rgb(75, 192, 192)", "rgb(153, 102, 255)", "rgb(201, 203, 207)"],
                borderWidth: 1
            }]
        };
        var ctx = $("#myChart").get(0).getContext("2d");
        var myNewChart = new Chart(ctx, {
            type: 'bar',
            data: dataT,
            options: {
                responsive: true,
                title: { display: true, text: 'Total de salários por departamento' },
                legend: { position: 'bottom' },
                scales: {
                    xAxes: [{ gridLines: { display: false }, display: true, scaleLabel: { display: false, labelString: '' } }],
                    yAxes: [{ gridLines: { display: false }, display: true, scaleLabel: { display: false, labelString: '' }, ticks: { stepSize: 50, beginAtZero: true } }]
                },
            }
        });
    }
});