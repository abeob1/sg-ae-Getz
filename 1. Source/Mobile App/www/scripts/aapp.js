/**
 * Angular App (aapp)
 */

var app = angular.module( 'getz' , [] );

app.controller( 'quoteCtrl' , ['$scope','$http', function($scope,$http)  {
  $scope.titles = [];
  
  
  $scope.addItem = function( item ) { 
    if ( !_.contains( $scope.titles , item.title ) ){
      $scope.titles.push( item.title );
    } 
    $scope.item = {};
  }
  
  $scope.getitem = function()
  {
	  console.log("before");
	  $http({
		  method: 'GET',
		  data: "ItemName=" + "s",
		  url: 'http://54.251.51.69:3883/Service.asmx/GetItem?ItemName=COMS',
		  transformResponse: function (cnv) {
              var x2js = new X2JS();
              var aftCnv = x2js.xml_str2json(cnv);              
              return aftCnv;
          }		 
		}).then(function successCallback(response) {
		    // this callback will be called asynchronously
		    // when the response is available	
			console.log(response);
			//$scope.xml = $(response).find("string").text();
			//console.log($scope.xml);
			$scope.obj_array = angular.toJson(response);
    		
    		
			$scope.titles = JSON.parse($scope.obj_array);
    		
    		
			alert("working");
			console.log(angular.fromJson($scope.titles.data[0]));
		  }, function errorCallback(response) {
		    // called asynchronously if an error occurs
		    // or server returns response with an error status.
			  console.log(angular.toJson(response));
			  console.log("error");
		  });
	  
	  
  }
  
 
  
}]);



                