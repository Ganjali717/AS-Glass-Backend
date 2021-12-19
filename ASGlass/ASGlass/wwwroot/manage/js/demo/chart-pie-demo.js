
$(document).ready(function () {

    // Set new default font family and font color to mimic Bootstrap's default styling
    Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
    Chart.defaults.global.defaultFontColor = '#858796';

    // Pie Chart Example
    var ctx = document.getElementById("myPieChart");

    var url = "https://localhost:44393/manage/dashboard/getproperty";

    fetch(url)
        .then(response => response.json())
            .then(data => {

                var myPieChart = new Chart(ctx, {
                    type: 'doughnut',
                    data: {
                        labels: ["Heyet Evi","Villa", "Yeni Tikili", "Kohne Tikili", "Bag Evi"],
                        datasets: [{
                            data: [data.heyetEviCount, data.villasCount, data.yeniTikiliCount, data.kohneTikiliCount, data.bagCount],
                            backgroundColor: ['#CC0000', '#4e73df', '#1cc88a', '#36b9cc', '#f6c23e'],
                            hoverBackgroundColor: ['#2e59d9', '#17a673', '#2c9faf'],
                            hoverBorderColor: "rgba(234, 236, 244, 1)",
                        }],
                    },
                    options: {
                        maintainAspectRatio: false,
                        tooltips: {
                            backgroundColor: "rgb(255,255,255)",
                            bodyFontColor: "#858796",
                            borderColor: '#dddfeb',
                            borderWidth: 1,
                            xPadding: 15,
                            yPadding: 15,
                            displayColors: false,
                            caretPadding: 10,
                        },
                        legend: {
                            display: false
                        },
                        cutoutPercentage: 80,
                    },
                });





            })


  


})