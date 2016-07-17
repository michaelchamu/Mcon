
  'use strict';

    /* this section gets all months to the current month*/
  var currentMonth, firstMonth, R_months = [], x, R_projects = [], C_projects = [], C_months = [], months = [], i = 0;
  firstMonth = moment.months(0);
  currentMonth = moment().format('Do, MMMM YYYY');
  for (x = 0; x <= moment().month() ; x++)
      months.push(moment.months(x));
  $("#date").html("<strong>Projects received, Projects completed for the period " +firstMonth+ " 1st to "+ currentMonth + "</strong>");

//array of count of completed projects
  var completedProjects = $("#completedProjectsList").val();
  var receivedProjects = $("#recievedProjects").val();

  var receivedProjectsArray = JSON.parse(receivedProjects);
  var completedProjectsArray = JSON.parse(completedProjects);

  if (receivedProjectsArray.length > 0) {
      for (i = 0; i < receivedProjectsArray.length; i++)
      {
          R_projects.push(receivedProjectsArray[i]['numberOfProjects']);
          R_months.push(receivedProjectsArray[i]['month']);
      }
  }

  if (completedProjectsArray.length > 0){
      for (i = 0; i < completedProjects.length; i++) {
          C_months.push(completedProjectsArray[i]['month']);
          C_projects.push(completedProjectsArray[i]['numberOfProjects']);
      }
  }
 
 /*
  while (receivedProjectsArray[i]) {
      R_projects.push(receivedProjectsArray[i]['numberOfProjects']);
      R_months.push(receivedProjectsArray[i]['months']);
  }
  while (completedProjects[i]) {
      C_months.push(completedProjects[i]['numberOfProjects']);
      C_projects.push(completedProjects[i]['months']);
  }
  */
//array of count of received projects['numberOfProjects'][
/* ChartJS
   * -------
   * Here we will create a few charts using ChartJS
   */

  //-----------------------
  //- MONTHLY SALES CHART -
  //-----------------------

  // Get context with jQuery - using jQuery's .get() method.
  var salesChartCanvas = $("#salesChart").get(0).getContext("2d");
  // This will get the first returned node in the jQuery collection.
  var salesChart = new Chart(salesChartCanvas);

  var salesChartData = {
      labels: R_months,//["January", "February", "March", "April", "May", "June", "July"],
    datasets: [
      {
        label: "Projects completed",
        fillColor: "rgb(210, 214, 222)",
        strokeColor: "rgb(210, 214, 222)",
        pointColor: "rgb(210, 214, 222)",
        pointStrokeColor: "#c1c7d1",
        pointHighlightFill: "#fff",
        pointHighlightStroke: "rgb(220,220,220)",
        data: C_projects//[1, 1, 0, 2, 0, 1]
      },
      {
        label: "Projects recieved",
        fillColor: "rgba(60,141,188,0.9)",
        strokeColor: "rgba(60,141,188,0.8)",
        pointColor: "#3b8bba",
        pointStrokeColor: "rgba(60,141,188,1)",
        pointHighlightFill: "#fff",
        pointHighlightStroke: "rgba(60,141,188,1)",
        data: R_projects//[7, 2, 4, 0, 0, 1]
      }
    ]
  };

  var salesChartOptions = {
    //Boolean - If we should show the scale at all
    showScale: true,
    //Boolean - Whether grid lines are shown across the chart
    scaleShowGridLines: false,
    //String - Colour of the grid lines
    scaleGridLineColor: "rgba(0,0,0,.05)",
    //Number - Width of the grid lines
    scaleGridLineWidth: 1,
    //Boolean - Whether to show horizontal lines (except X axis)
    scaleShowHorizontalLines: true,
    //Boolean - Whether to show vertical lines (except Y axis)
    scaleShowVerticalLines: true,
    //Boolean - Whether the line is curved between points
    bezierCurve: true,
    //Number - Tension of the bezier curve between points
    bezierCurveTension: 0.3,
    //Boolean - Whether to show a dot for each point
    pointDot: false,
    //Number - Radius of each point dot in pixels
    pointDotRadius: 4,
    //Number - Pixel width of point dot stroke
    pointDotStrokeWidth: 1,
    //Number - amount extra to add to the radius to cater for hit detection outside the drawn point
    pointHitDetectionRadius: 20,
    //Boolean - Whether to show a stroke for datasets
    datasetStroke: true,
    //Number - Pixel width of dataset stroke
    datasetStrokeWidth: 2,
    //Boolean - Whether to fill the dataset with a color
    datasetFill: true,
    //String - A legend template
    legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].lineColor%>\"></span><%=datasets[i].label%></li><%}%></ul>",
    //Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
    maintainAspectRatio: true,
    //Boolean - whether to make the chart responsive to window resizing
    responsive: true
  };

  //Create the line chart
  salesChart.Line(salesChartData, salesChartOptions);

  //---------------------------
  //- END MONTHLY SALES CHART -
  //---------------------------

  /* jVector Maps
   * ------------
   * Create a world map with markers
   */
  $('#world-map-markers').vectorMap({
      map: 'africa_mill',
    normalizeFunction: 'polynomial',
    hoverOpacity: 0.7,
    focusOn: 'NA',
    hoverColor: false,
    backgroundColor: 'transparent',
    regionStyle: {
      initial: {
        fill: 'rgba(210, 214, 222, 1)',
        "fill-opacity": 1,
        stroke: 'none',
        "stroke-width": 0,
        "stroke-opacity": 1
      },
      hover: {
        "fill-opacity": 0.7,
        cursor: 'pointer'
      },
      selected: {
        fill: 'yellow'
      },
      selectedHover: {
      }
    },
    markerStyle: {
      initial: {
        fill: '#00a65a',
        stroke: '#111'
      }
    },
    markers: [

      { latLng: [-22.679005, 14.531050], name: 'Swakopmund' }
     /* {latLng: [-26.01721, 16.90105], name: 'Farm Sterreprag(Helmeringhausen)'},
      {latLng: [-27.52284, 17.81388], name: 'FishRiver Canyon Roadhouse'},
      {latLng: [-20.299165, 15.173725], name: 'Damara Mopane(Khorixas)'},
      {latLng: [-21.46354, 17.84919], name: 'Hartebeestteich-Sud(Hochfeld )'},
      {latLng: [-17.98636, 23.29582], name: 'Namushasha River Lodge(Kongola)'},
      {latLng: [-22.575459, 17.073849], name: 'Olympia(Windhoek)'},
      {latLng: [-22.780311, 18.017803], name: 'Eningu Clayhouse Lodge(Nina)'}*/
    ]
  });

  /* SPARKLINE CHARTS
   * ----------------
   * Create a inline charts with spark line
   */

  //-----------------
  //- SPARKLINE BAR -
  //-----------------
  $('.sparkbar').each(function () {
    var $this = $(this);
    $this.sparkline('html', {
      type: 'bar',
      height: $this.data('height') ? $this.data('height') : '30',
      barColor: $this.data('color')
    });
  });

  //-----------------
  //- SPARKLINE PIE -
  //-----------------
  $('.sparkpie').each(function () {
    var $this = $(this);
    $this.sparkline('html', {
      type: 'pie',
      height: $this.data('height') ? $this.data('height') : '90',
      sliceColors: $this.data('color')
    });
  }); 

  //------------------
  //- SPARKLINE LINE -
  //------------------
  $('.sparkline').each(function () {
    var $this = $(this);
    $this.sparkline('html', {
      type: 'line',
      height: $this.data('height') ? $this.data('height') : '90',
      width: '100%',
      lineColor: $this.data('linecolor'),
      fillColor: $this.data('fillcolor'),
      spotColor: $this.data('spotcolor')
    });
  });
