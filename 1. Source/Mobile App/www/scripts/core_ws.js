
	
	var url_src = "http://175.139.255.189:3001/Service.asmx/";
	//var url_src = "http://172.17.65.247:81/Service.asmx/";
	//var url_src = "http://54.251.51.69:3883/Service.asmx/";
	

	var vehicle_id = "", employee_id = "";
	var targetted_date;
	var LastSyncDate = "6/1/2014"; //mm/dd/yyyy
	var obj_array_notifications, obj_array_timelines, obj_array_damages, obj_array_causes, obj_array_parts, obj_array_van_parts, obj_array_quotation_header, obj_array_quotation_detail, obj_array_message;

	var array_parts_upload = [];
	var array_damages_upload = []; 
	var array_causes_upload = []; 
	var array_timeline_upload = [];
	var array_quotation_upload = [];
	var array_quotation_detail_upload = []; 
	var array_checklist_header_upload = []; 
	var array_checklist_detail_upload = [];
	var array_signature_upload = [];  
	var array_survey_upload = []; 
	
	var obj_array_masterlookup_download = [];
	
	var LastSyncDateTime = "";
	
	
    function ShowJSON () {

    	$("#textbox_json").val(JSON.stringify(current_notification));
    }


    function errorCB(tx, err) {
    	
        alert("Error processing SQL: "+err);
    }

    
    function TestUpload () {

    	//array_notifications_upload[0] = current_notification;
    	
    	console.log("testcaled");
    	
    	$.ajax ({

			type: "GET",
			url: url_src + "DownloadMasterLookUp",
			crossDomain: true,     
			data: "dtCreated=" + LastSyncDate,
			//data: "dtCreated=" + "05/17/2012",
			dataType: "xml",
			success: DownloadMasterLookupSuccess,
			error: SyncError

		});	  
		

    }

    function TestUploadSuccess () {
    	alert("Upload success");
    }

	function SyncError(request, status, error) {
    	
		if(request.responseText.length > 0){

	    	alert("Error: " + request.responseText);
	    	$.isLoading( "hide" );
		} else {
			$.isLoading( "hide" );
		}
		
	}



	// follow upload sequence:
	// Notification, Parts, Damages, Causes, Timeline, QuotationHeader, QuotationDetail, ChecklistHeader, ChecklistDetail, Signature, Survey, TravelBack

	// Upload Data
	function UploadNotification () {

		
		$('body').isLoading({ text: "Upload Notification" });
		
		if (array_notifications_upload.length > 0) {
			
			$.ajax ({

				type: "POST",
				url: url_src + "UploadOpNotificationByJSON",
				crossDomain: true,    
				data: "json=" + encodeURIComponent(JSON.stringify(array_notifications_upload)),
				dataType: "html",
				success: UploadNotificationSuccess,
				error: SyncError	
				
			});		
		} else {
		
			SyncDataBtwSAPSQL();
		}
		//$.isLoading( "hide" );


	}

	function UploadNotificationSuccess () {
			
		GetOpPartCollection();
		//UploadOpParts();
	}

	
	function GetOpPartCollection () {
		
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Upload Parts" });
		
		db.transaction(function(tx) {
    		tx.executeSql("select * from op_parts ;", [], GetOpPartCollection_querySuccess, errorCB);
    	});
		
	}
	
	
	function GetOpPartCollection_querySuccess (tx, results) {
	
		array_parts_upload = [];
		
		var len = results.rows.length;
		
		for (var i=0; i< len; i++) {
			array_parts_upload[i] = results.rows.item(i);
			
		}

		
		
		UploadOpParts();
	}
	
	
	function UploadOpParts () {

		if (array_parts_upload.length > 0) {
			
			$.ajax ({

				type: "POST",
				url: url_src + "UploadOpPartByJSON",
				crossDomain: true,    
				data: "json=" + encodeURIComponent(JSON.stringify(array_parts_upload)),
				dataType: "html",
				success: UploadOpPartsSuccess,
				error: SyncError	
				
				
			});		
		} else {
			GetOpDamagesCollection();
		}
		
	}
	

	function UploadOpPartsSuccess () {

		db.transaction(function(tx) {
    		tx.executeSql("delete from op_parts ;", [], GetOpDamagesCollection, errorCB);
    	});

	}

	function GetOpDamagesCollection () {
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Upload Damages" });
		
		db.transaction(function(tx) {
    		tx.executeSql("select * from op_damages where op_sys ='0' and damage_notification in " +
    				"(select op_notification.internal_id from op_notification where (notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and notification_sapready  = '1' and notification_resp = '"+ current_login.user_id +"' );", [], GetOpDamagesCollection_querySuccess, errorCB);
    	});
		
		
	}
	
	
	function GetOpDamagesCollection_querySuccess(tx, results) {

		array_damages_upload = [];
		
		var len = results.rows.length;
		
		for (var i=0; i< len; i++) {
			array_damages_upload[i] = results.rows.item(i);
			
		}

		UploadDamages();
	}
	
	function UploadDamages () {
	
		if (array_damages_upload.length > 0) {
			$.ajax ({			
				type: "POST",
				url: url_src + "UploadOpDamagesByJSON",
				crossDomain: true,     
				data: "json=" + encodeURIComponent(JSON.stringify(array_damages_upload)),
				dataType: "html",
				success: UploadDamagesSuccess,
				error: SyncError			
			});
		}  else {
			GetCausesCollection(); 
		}
		
	}
	
	function UploadDamagesSuccess () {

		GetCausesCollection(); 

	}

	function GetCausesCollection() { 
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Upload Causes" });
		
		db.transaction(function(tx) {
    		tx.executeSql("select * from op_causes where op_sys ='0' and cause_notification in " +
    				"(select op_notification.internal_id from op_notification where ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and notification_sapready  = '1' and notification_resp = '"+ current_login.user_id +"' );", [], GetCausesCollection_querySuccess, errorCB);
    	});
		
	}
	
	function GetCausesCollection_querySuccess(tx, results) { 
		
		array_causes_upload = []
		var len = results.rows.length;
		
		for (var i=0; i< len; i++) {
			array_causes_upload[i] = results.rows.item(i);
		}
		
		UploadCauses ();
		
	}
	
	
	function UploadCauses () {
		
		if (array_causes_upload.length > 0) {
			$.ajax ({
				type: "POST",
				url: url_src + "UploadOpCausesByJSON",
				crossDomain: true,     
				data: "json=" + encodeURIComponent(JSON.stringify(array_causes_upload)),
				dataType: "html",
				success: UploadCausesSuccess,
				error: SyncError			
			});
		} else {
			GetTimelineCollection();
		}
	}

	function UploadCausesSuccess () {

		GetTimelineCollection();
	}


	function GetTimelineCollection() {
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Upload Timeline" });
		
		db.transaction(function(tx) {
    		tx.executeSql("select * from op_timestamp where job_status = 'JE' and op_updated_from_sap = '0' and tstamp_notification in " +
    				"(select op_notification.internal_id from op_notification where (notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and notification_sapready  = '1' and notification_resp = '"+ current_login.user_id +"' );", [], GetTimelineCollection_querySuccess, errorCB);
    	});
		
	}
		
	function GetTimelineCollection_querySuccess (tx, results) {
		
		array_timeline_upload = []
		
		var len = results.rows.length;
				
		for (var i=0; i< len; i++) {

			array_timeline_upload[i] = new obj_timestamp(results.rows.item(i).internal_id);
			array_timeline_upload[i].internal_id = results.rows.item(i).internal_id;
			array_timeline_upload[i].tstamp_notification = results.rows.item(i).tstamp_notification;
			array_timeline_upload[i].job_date = new Date(results.rows.item(i).job_date);
			array_timeline_upload[i].job_travel = results.rows.item(i).job_travel;
			array_timeline_upload[i].job_waiting = results.rows.item(i).job_waiting;
			array_timeline_upload[i].job_travel_start = new Date(results.rows.item(i).job_travel_start);
			array_timeline_upload[i].job_travel_end = new Date(results.rows.item(i).job_travel_end);
			array_timeline_upload[i].job_waiting_start = new Date(results.rows.item(i).job_waiting_start);
			array_timeline_upload[i].job_waiting_end = new Date(results.rows.item(i).job_waiting_end);
			array_timeline_upload[i].job_start = new Date(results.rows.item(i).job_start);
			array_timeline_upload[i].job_end = new Date(results.rows.item(i).job_end);
			array_timeline_upload[i].job_description = results.rows.item(i).job_description;
			array_timeline_upload[i].job_status = results.rows.item(i).job_status;
			array_timeline_upload[i].job_by = results.rows.item(i).job_by;
			array_timeline_upload[i].op_updated_from_sap = results.rows.item(i).op_updated_from_sap;
			array_timeline_upload[i].op_shared = results.rows.item(i).op_shared;
			
			
		}
		
		UploadTimeline();
	}
	
	function UploadTimeline () {

		if (array_timeline_upload.length > 0) {
			$.ajax ({
				type: "POST",
				url: url_src + "UploadOpTimeStampByJSON",
				crossDomain: true,     
				data: "json=" + encodeURIComponent(JSON.stringify(array_timeline_upload)),
				dataType: "html",
				success: UploadTimelineSuccess,
				error: SyncError			
			});
		} else {
			GetOpQuotationCollection();
		}
	}
	
	function UploadTimelineSuccess () {


		db.transaction(function(tx) {
    		tx.executeSql("delete from op_timestamp ;", [], GetOpQuotationCollection, errorCB);
    	});
	
		
	}

	function GetOpQuotationCollection() {

		db.transaction(function(tx) {
    		tx.executeSql("select * from op_quotation where quotation_notification in " +
    				"(select op_notification.internal_id from op_notification where ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and notification_sapready  = '1' and notification_resp = '"+ current_login.user_id +"' );", [], GetOpQuotationCollection_querySuccess, errorCB);
    	});
		
	}
	
	function GetOpQuotationCollection_querySuccess(tx, results) {
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Upload Quotation" });
		
		array_quotation_upload = []; 
		
		var len = results.rows.length;
		
		if (len > 0) {
			for (var i=0; i< len; i++) {
				
				array_quotation_upload[i] = new obj_quotation_header(results.rows.item(i).quotation_notification);
				
				array_quotation_upload[i] = results.rows.item(i);
				array_quotation_upload[i].quotation_date = new Date(results.rows.item(i).quotation_date);
				array_quotation_upload[i].quotation_validfrom = new Date(results.rows.item(i).quotation_validfrom);
				array_quotation_upload[i].quotation_validto = new Date(results.rows.item(i).quotation_validto);
				
			}
			
			UploadOpQuotation ();
		}
		else {
			GetChecklistHeaderCollection();
		}

	}


	function UploadOpQuotation()  {

		if (array_quotation_upload.length > 0) {
			$.ajax ({
				type: "POST",
				url: url_src + "UploadOpQuotationByJSON",
				crossDomain: true,     
				data: "json=" + encodeURIComponent(JSON.stringify(array_quotation_upload)),
				dataType: "html",
				success: UploadOpQuotationSuccess,
				error: SyncError			
			});
		} else {
			GetOpQuotationCollection(); 
		}

	}	
	

	function UploadOpQuotationSuccess() {
		
		GetOpQuotationCollectionDetail();
		
		//db.transaction(function(tx) {
    	//	tx.executeSql("delete from op_quotation ;", [], GetOpQuotationCollectionDetail, errorCB);
    	//});
		
		
	}

	function GetOpQuotationCollectionDetail () {
		
		db.transaction(function(tx) {
    		tx.executeSql("select * from op_quotation_detail where detail_quotation in " +
    				"(select op_quotation.internal_id from op_quotation where quotation_notification in " +
    				"(select op_notification.internal_id from op_notification where ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and notification_sapready  = '1' and notification_resp = '"+ current_login.user_id +"' ));", [], GetOpQuotationCollectionDetail_querySuccess, errorCB);
    	});
	}
	
	function GetOpQuotationCollectionDetail_querySuccess(tx, results){

		array_quotation_detail_upload = [];
		var len = results.rows.length;
		
		for (var i=0; i< len; i++) {
			
			array_quotation_detail_upload[i] = results.rows.item(i);
		}

		UploadOpQuotationDetail ();
	}

	function UploadOpQuotationDetail()  {

		if (array_quotation_detail_upload.length > 0) {
			$.ajax ({
				type: "POST",
				url: url_src + "UploadOpQuotationDetailByJSON",
				crossDomain: true,     
				data: "json=" + encodeURIComponent(JSON.stringify(array_quotation_detail_upload)) ,
				dataType: "html",
				success: UploadOpQuotationDetailSuccess,
				error: SyncError		
			});
		}

	}		

	function UploadOpQuotationDetailSuccess () {
		
		
		var quotation_header_len = array_quotation_upload.length;
		
		if(quotation_header_len > 0) {
			
			db.transaction(function(tx) {
	    		tx.executeSql("delete from op_quotation ;", [], "", errorCB);
	    	});
			
			db.transaction(function(tx) {
	    		tx.executeSql("delete from op_quotation_detail ;", [], "", errorCB);
	    	});
			
			//for (var i=0; i< quotation_header_len; i++) {
				
			//	db.transaction(function(tx) {
		   // 		tx.executeSql("delete from op_quotation_detail where detail_quotation = '"+ array_quotation_upload[i].internal_id +"';", [], "", errorCB);
		   // 	});
			//}
	
		}
	
		GetChecklistHeaderCollection();
		

	}


	function GetChecklistHeaderCollection () {
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Upload Checklist" });
		
		db.transaction(function(tx) {
    		tx.executeSql("select * from op_checklist_header where notification_id in " +
    				"(select op_notification.internal_id from op_notification where ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and notification_sapready  = '1' and notification_resp = '"+ current_login.user_id +"' );", [], GetChecklistHeaderCollection_querySuccess, errorCB);
    	});
		
	}
	

	function GetChecklistHeaderCollection_querySuccess(tx, results){
		
		array_checklist_header_upload = [];
		
		var len = results.rows.length;
		
		if(len > 0){
			
			for (var i=0; i< len; i++) {

				array_checklist_header_upload[i] = new obj_checklist_header(results.rows.item(i).notification_id);
				array_checklist_header_upload[i] = results.rows.item(i);
				array_checklist_header_upload[i].checklist_date = new Date(results.rows.item(i).checklist_date);

			}
			
			UploadOpCheckistHeader ();
			
		} else {
			GetOpSignatureCollection(); 
		}

	}

	function UploadOpCheckistHeader () {

		if (array_checklist_header_upload.length > 0) {
			$.ajax ({
				type: "POST",
				url: url_src + "UploadOpCheckListHeaderByJSON",
				crossDomain: true,     
				data: "json=" + encodeURIComponent(JSON.stringify(array_checklist_header_upload)) ,
				dataType: "html",
				success: UploadOpCheckistHeaderSuccess,
				error: SyncError	
			});		
		} else {
			GetOpSignatureCollection(); 
		}

	}
	
	function UploadOpCheckistHeaderSuccess () {
		
		GetChecklistDetail();
		
		//db.transaction(function(tx) {
    	//	tx.executeSql("delete from op_checklist_header where notification_id in " +
    	//			"(select op_notification.internal_id from op_notification where notification_requiredstart <= '"+ date_to +"' and notification_sapready  = '1' and notification_resp = '"+ current_login.user_id +"' );", [], GetChecklistDetail, errorCB);
    	//});
		
	}

	function GetChecklistDetail () {
		
		db.transaction(function(tx) {
    		tx.executeSql("select * from op_checklist_detail where checklist_header_id in " +
    				"(select op_checklist_header.internal_id from op_checklist_header where notification_id in " +
    				"(select op_notification.internal_id from op_notification where (notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and notification_sapready  = '1' and notification_resp = '"+ current_login.user_id +"' ) " +
    				") ;", [], GetChecklistDetail_querySuccess, errorCB);
    	});
		
	}
	

	function GetChecklistDetail_querySuccess(tx, results) {
		
		array_checklist_detail_upload = [];
		var len = results.rows.length;
		
		if (len > 0) {
			for (var i=0; i< len; i++) {
				array_checklist_detail_upload[i] = results.rows.item(i);
			}
			
			UploadOpCheckListDetail(); 
		} else {
			GetOpSignatureCollection(); 
		}

	}
	

	function UploadOpCheckListDetail () {
		
		if (array_checklist_detail_upload.length > 0) {
			$.ajax ({
				type: "POST",
				url: url_src + "UploadOpCheckListDetailByJSON",
				crossDomain: true,     
				//data: "json=" + JSON.stringify(array_checklist_detail_upload),
				data: "json=" + encodeURIComponent(JSON.stringify(array_checklist_detail_upload)) ,
				dataType: "html",
				success: UploadOpCheckListDetailSuccess,
				error: SyncError	
			});		
		}else {
			GetOpSignatureCollection(); 
		}		
	}
	

	function UploadOpCheckListDetailSuccess () {

		var checklist_detail_len = array_checklist_detail_upload.length; 
		
		if(array_checklist_header_upload.length > 0 ){
			db.transaction(function(tx) {
	    		tx.executeSql("delete from op_checklist_header where notification_id in " +
	    				"(select op_notification.internal_id from op_notification where (notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and notification_sapready  = '1' and notification_resp = '"+ current_login.user_id +"' );", [], "", errorCB);
	    	});
		}
		
		if (checklist_detail_len > 0) {
			
			for (var i=0; i< checklist_detail_len; i++) {
				
				db.transaction(function(tx) {
		    		tx.executeSql("delete from op_checklist_detail where internal_id = '" + array_checklist_detail_upload[i].internal_id + "' ;", [], "", errorCB);
		    	});
				
			}
			
		}
		
		GetOpSignatureCollection(); 

	}

	function GetOpSignatureCollection(){
		
		
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Upload Signature" });
		
		db.transaction(function(tx) {
    		tx.executeSql("select notification_id, notification_signature, signature_name, signature_contact, signature_dept, signature_designation from op_signature where notification_id in " +
    				"(select op_notification.internal_id from op_notification where (notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and notification_sapready  = '1' and notification_resp = '"+ current_login.user_id +"' );", [], GetOpSignatureCollection_querySuccess, errorCB);
    	});
		
	}
	
	function GetOpSignatureCollection_querySuccess(tx, results) {
		
		array_signature_upload = [];
		var len = results.rows.length;
	
		if(len > 0){
			
			for (var i=0; i< len; i++) {
				array_signature_upload[i] = results.rows.item(i);
			}
			
			UploadOpSignature();
			
		}else {
			GetOpSurveyCollection();
			//GetOpTravelBackCollection();
		}

		
	}
	
	function UploadOpSignature()  {


		if (array_signature_upload.length > 0) {
			$.ajax ({
				type: "POST",
				url: url_src + "UploadOpSignatureByJSON",
				crossDomain: true,     
				//data: "json=" + JSON.stringify(array_signature_upload),
				data: "json=" + encodeURIComponent(JSON.stringify(array_signature_upload)) ,
				dataType: "html",
				success: UploadOpSignatureSuccess,
				error: SyncError			
			});
		} else {
			GetOpSurveyCollection();
		}

	}

	function UploadOpSignatureSuccess()  {
		

		db.transaction(function(tx) {
    		tx.executeSql("delete from op_signature where notification_id in " +
    				"(select op_notification.internal_id from op_notification where (notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and notification_sapready  = '1' and notification_resp = '"+ current_login.user_id +"' );", [], "", errorCB);
    	});
		
		GetOpSurveyCollection();
	
	}
	
	function GetOpSurveyCollection () {
		

		db.transaction(function(tx) {
    		tx.executeSql("select * from op_survey where survey_notification in " +
    				"(select op_notification.internal_id from op_notification where ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and notification_sapready  = '1' and notification_resp = '"+ current_login.user_id +"' );", [], GetOpSurveyCollection_querySuccess, errorCB);
    	});
		
	}
	
	function GetOpSurveyCollection_querySuccess(tx, results) {
		
		array_survey_upload = [];
		var len = results.rows.length;
		
		if(len > 0){
			for (var i=0; i< len; i++) {
				//array_survey_upload[i] = results.rows.item(i);
				
				array_survey_upload[i] = new obj_survay(results.rows.item(i).internal_id);
				array_survey_upload[i].internal_id = results.rows.item(i).internal_id;
				array_survey_upload[i].survey_notification = results.rows.item(i).survey_notification;
				array_survey_upload[i].survey_comments = results.rows.item(i).survey_comments;
				array_survey_upload[i].survey_date = new Date(results.rows.item(i).survey_date);
				array_survey_upload[i].survey_remarks = results.rows.item(i).survey_remarks;
				
				
			}
			UploadOpSurvey ();
		} else {
			GetOpTravelBackCollection();
		}
		
	}
	
	
	function UploadOpSurvey()  {

		if (array_survey_upload.length > 0) {
			$.ajax ({			
				type: "POST",
				url: url_src + "UploadOpSurveyByJSON",
				crossDomain: true,     
				//data: "json=" + JSON.stringify(array_survey_upload),
				data: "json=" + encodeURIComponent(JSON.stringify(array_survey_upload)) ,
				dataType: "html",
				success: UploadOpSurveySuccess,
				error: SyncError			
			});
		} else {
			GetOpTravelBackCollection();
		}
	
	}	

	function UploadOpSurveySuccess () {
		
		//DeleteOpSurvey
		db.transaction(function(tx) {
    		tx.executeSql("delete from op_survey where survey_notification in " +
    				" (select op_notification.internal_id from op_notification where (notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and notification_sapready  = '1' and notification_resp = '"+ current_login.user_id +"') ;", [], "" , errorCB);
    	});
		
		GetOpTravelBackCollection(); 
	}

	function GetOpTravelBackCollection () {
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Upload Travel Back" });
		
		db.transaction(function(tx) {
    		tx.executeSql("select * from op_travelback where notification_id in " +
    				"(select op_notification.internal_id from op_notification where (notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and notification_sapready  = '1' and notification_resp = '"+ current_login.user_id +"' );", [], GetOpTravelBackCollection_querySuccess, errorCB);
    	});
		
	}
	
	function GetOpTravelBackCollection_querySuccess(tx, results) {

		array_travel_back = [];
		var len = results.rows.length;
		
		if(len > 0){
			for (var i=0; i< len; i++) {
				
				array_travel_back[i] = new obj_travelback(results.rows.item(i).notification_id); 
				array_travel_back[i] = results.rows.item(i);
				array_travel_back[i].time_start = new Date(results.rows.item(i).time_start);
				array_travel_back[i].time_end = new Date(results.rows.item(i).time_end);
				
			}
			
			UploadOpTravelBack ();
			
		} else {
			UploadOpTravelBackSuccess();
		}

	}
	
	function UploadOpTravelBack () {

		if (array_travel_back.length > 0) {
			$.ajax ({
				type: "POST",
				url: url_src + "UploadOpTravelBackByJSON",
				crossDomain: true,     
				//data: "json=" + JSON.stringify(array_travel_back),
				data: "json=" + encodeURIComponent(JSON.stringify(array_travel_back)) ,
				dataType: "html",
				//success: UploadOpTravelBackSuccess,
				success: UploadOpTravelBackSuccess,
				error: SyncError			
			});
		} else {
			UploadOpTravelBackSuccess();
		}
	}


	function UploadOpTravelBackSuccess () {
		
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Data Upload Completed" });
		
		GetOpMessageCollection(); 

		
	}

	function GetOpMessageCollection(){
		
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Upload Message" });

		db.transaction(function(tx) {
    		tx.executeSql("select * from op_message where msg_isread = '1' and msg_arrival_date >= ( select dt_last_sync from tmp_sync) and engineer_id = '" + current_login.user_id +"' ;", [], GetOpMessageCollection_querySuccess, errorCB);
    	});
		
		
	}
	
	function GetOpMessageCollection_querySuccess(tx, results){

		array_message = [];
		var len = results.rows.length;
		
		if(len > 0){
			for (var i=0; i< len; i++) {
				
				array_message[i] = new obj_message(results.rows.item(i).internal_id); 
				
				array_message[i] = results.rows.item(i);
				array_message[i].internal_id = results.rows.item(i).internal_id;
				array_message[i].engineer_id = new Date(results.rows.item(i).engineer_id);
				array_message[i].msg_date = new Date(results.rows.item(i).msg_date);
				array_message[i].msg_arrival_date = new Date(results.rows.item(i).msg_arrival_date);
				array_message[i].msg_text = results.rows.item(i).msg_text;
				array_message[i].msg_isread = results.rows.item(i).msg_isread;
				
			}
			
			UploadMessage ();
			
		} else {
			UploadMessageSuccess();
		}

		
	}

	function UploadMessage(){
				
		if (array_message.length > 0) {
			$.ajax ({
				type: "POST",
				url: url_src + "UploadMessageByJSON",
				crossDomain: true,     
				data: "json=" + encodeURIComponent(JSON.stringify(array_message)) ,
				dataType: "html",
				success: UploadMessageSuccess,
				error: SyncError			
			});
		} else {
			UploadMessageSuccess();
		}
		
	}
	
	function UploadMessageSuccess(){
		
		$('body').isLoading({ text: "Upload Completed" });
		$.isLoading( "hide" );
		
		//Begin Download process after uploading job completed
		SyncDataBtwSAPSQL();
	}
	
	
	
	
	
	
	/////////// Download Data ///////////
	
	// Download Equipment History
	function DownloadEquipmentHistory (equipmentid) {
		$.ajax ({

			type: "POST",
			url: url_src + "DownloadHistoryByEquipmentID",
			crossDomain: true,     
			data: "EquipmentID=" + equipmentid,			
			dataType: "xml",
			success: DownloadEquipmentHistorySucecss,
			error: SyncError

		})
	}

	function DownloadEquipmentHistorySucecss(data, status) {

		$("#" + TAB_DETAIL_HISTORY_EQUIPMENT + " tr:gt(0)").remove();
		
    	if (data != "") {
    		var xml = $(data).find("string").text();

    		// parse json
    		var obj = $.parseJSON (xml);
    		if (obj.length > 0) {

    			for (var x = 0; x < obj.length; x++) {

    				// display oject properties, start to generate html
	    			obj_content = "";
					for (var prop in obj[x]) {
	    				obj_content += ("obj." + prop + " = " + obj[x][prop] + "\r");
					}

					$("#" + TAB_DETAIL_HISTORY_EQUIPMENT + " > tbody:last").append("<tr> <td>"+ obj[x].notification_no.replace(/\\n/g, "<br />") +"</td> " +
							"<td>"+ obj[x].notification_subject.replace(/\\n/g, "<br />") +"</td> <td>"+ obj[x].Damages.replace(/\\n/g, "<br />") +"</td> <td>"+ obj[x].Causes.replace(/\\n/g, "<br />") +"</td> <td>"+  obj[x].Parts.replace(/\\n/g, "<br />") +"</td> </tr>");

					
				}

    		}


    	}
	}
	
	function SyncDataBtwSAPSQL () {
		
		$('body').isLoading({ text: "Sync Data Between SAP and SQL" });
		
		$.ajax ({

			type: "POST",
			url: url_src + "SyncMasterDAtaSQLSAP",
			crossDomain: true,
			dataType: "xml",
			success: SyncDataBtwSAPSQLSucecss,
			error: SyncError

		})
		
	}
	
	function SyncDataBtwSAPSQLSucecss () { 
		
		//GetLastSyncDate(); 
		DownloadMasterLookup();
		
	}
	
	function GetLastSyncDate() { 

		db.transaction(function(tx) {
    		tx.executeSql("select * from tmp_sync ;", [], GetLastSyncDate_querySuccess, errorCB);
    	});
		
	}

	function GetLastSyncDate_querySuccess(tx, results) {
		
		if (results.rows.length > 0){

			//added on 20150116
			LastSyncDateTime = new Date(results.rows.item(0).dt_last_sync);
			
			var tmpLastSyncDate = new Date(results.rows.item(0).dt_last_sync);
			tmpLastSyncDate.setDate(tmpLastSyncDate.getDate() + 1); 
		    var twoDigitMonth = tmpLastSyncDate.getMonth()+1;

		    if(twoDigitMonth.length==1)  twoDigitMonth="0" +twoDigitMonth;
		    
			var twoDigitDate = tmpLastSyncDate.getDate()+"";
			if(twoDigitDate.length==1) twoDigitDate="0" +twoDigitDate;
			//mm/dd/yyyy
			LastSyncDate = twoDigitMonth + "/" + twoDigitDate + '/' + tmpLastSyncDate.getFullYear();
			
		} else {
			
			LastSyncDateTime = new Date();
			var tmpLastSyncDate = new Date();
			tmpLastSyncDate.setDate(tmpLastSyncDate.getDate() + 1); 
		    var twoDigitMonth = tmpLastSyncDate.getMonth()+1;

		    if(twoDigitMonth.length==1)  twoDigitMonth="0" +twoDigitMonth;
		    
			var twoDigitDate = tmpLastSyncDate.getDate()+"";
			if(twoDigitDate.length==1) twoDigitDate="0" +twoDigitDate;
			//mm/dd/yyyy
			LastSyncDate = twoDigitMonth + "/" + twoDigitDate + '/' + tmpLastSyncDate.getFullYear();
		}
		

		DownloadMasterLookup();
		
	}
	
	
function DownloadMasterLookup () {


		$.isLoading( "hide" );
		$('body').isLoading({ text: "Downloading MasterLookup..." });
		
		$.ajax ({

			type: "POST",
			url: url_src + "DownloadMasterLookUp",
			crossDomain: true,     
			data: "dtCreated=" + LastSyncDate,
			//data: "dtCreated=" + "2/23/2016",
			dataType: "xml",
			success: DownloadMasterLookupSuccess,
			error: SyncError

		});
		
	}
	
	function DownloadMasterLookupSuccess (data, status) {
		
		
		
    	if (data != "") {
    		
    		var count=0;
    		//var xml = $(data).find("string").text();
    		var xml = $(data).find("string").text();
    		var obj_array = $.parseJSON (xml);
    		console.log(xml);
  
    		console.log((new XMLSerializer()).serializeToString(data));
    		console.log($.parseJSON (data));
    		
if(obj_array.length>0)
	count= obj_array.length;

    		
    		$.isLoading( "hide" );
    		$('body').isLoading({ text: "Total Master Lookup: " + count });
			
    		
    		if(obj_array.length > 0) {
    			
    			for (var x=0; x < obj_array.length; x++) {
    				//update into database 
    				
    				if(CheckExistExist(obj_array[x].master_id, obj_array[x].master_type )) {
    					console.log("Masterlook Update "+obj_array[x].master_id);
    					//update
    					db.transaction(function(tx) {
    			    		tx.executeSql("update master_lookup set master_desc = '"+ obj_array[x].master_desc +"' where master_id = '"+ obj_array[x].master_id +"' and master_type = '" + obj_array[x].master_type + "' ;", [], "" , errorCB);
    			    	});
    					
    				} else {
    					//insert
    					console.log("Masterlook insert "+obj_array[x].master_id);
    					db.transaction(function(tx) {
    			    		tx.executeSql("insert into master_lookup (master_id, master_desc, master_type ) " +
    			    				"values ('" + obj_array[x].master_id + "', '" + obj_array[x].master_desc + "', '" + obj_array[x].master_type + "') ;", [], "" , errorCB);
    			    	});
    					
    				}
    			}
    		}

    	}
    	
    	DownloadMasterUsers();
	}
	
	function UpdateMasterLookup(obj_array) {

		if(obj_array.length > 0) {
			
			for (var x=0; x < obj_array.length; x++) {
				//update into database 
				
				if(CheckExistExist(obj_array[x].master_id, obj_array[x].master_type )) {
					//update
					db.transaction(function(tx) {
			    		tx.executeSql("update master_lookup set master_desc = '"+ obj_array[x].master_desc +"' where master_id = '"+ obj_array[x].master_id +"' and master_type = '" + obj_array[x].master_type + "' ;", [], "" , errorCB);
			    	});
					
				} else {
					//insert
					db.transaction(function(tx) {
			    		tx.executeSql("insert into master_lookup (master_id, master_desc, master_type ) " +
			    				"values ('" + obj_array[x].master_id + "', '" + obj_array[x].master_desc + "', '" + obj_array[x].master_type + "') ;", [], "" , errorCB);
			    	});
					
				}
			}
		}
		
		DownloadMasterUsers();

	}
	
	function CheckExistExist (master_id, master_type){

		var IsExist = false; 
console.log("select * from master_lookup where master_id = '"+ master_id +"' and master_type = '" + master_type + "' ;");
		
		db.transaction(function(tx) {
    		tx.executeSql("select * from master_lookup where master_id = '"+ master_id +"' and master_type = '" + master_type + "' ;", [], function(tx, results) {	

    			if (results.rows.length > 0){			
    				IsExist = true;
    			} else {
    				IsExist = false
    			}
    		}
    		
    		 , errorCB);
    	});
		
		
				//console.log("thomastest"+ IsExist);
		return IsExist;
	}
	
	
	function DownloadMasterUsers() {

		$.isLoading( "hide" );
		$('body').isLoading({ text: "Downloading Master Users..." });
		
		$.ajax ({
			type: "POST",
			url: url_src + "DownloadMasterUsersByJSON",
			crossDomain: true,  
			data: "dtCreated=" + LastSyncDate,
			//data: "dtCreated=" + "07/07/2013",
			dataType: "xml",
			success: DownloadMasterUsersSuccess,
			error: SyncError			
		});		
		
		
	}
	
	function DownloadMasterUsersSuccess (data, status) {

    	if (data != "") {
    		var xml = $(data).find("string").text();

    		// parse json
    		var obj = $.parseJSON (xml);
    		var sql = [];
    		
    		if (obj.length > 0) {

    			$.isLoading( "hide" );
        		$('body').isLoading({ text: "Total Master Users: " + obj.length });
    			
    			for (var x = 0; x < obj.length; x++) {
    				
    				

    				if(CheckUserExist(obj[x].InternalID) == true){
    					//update
    					
    					
    					db.transaction(function(tx) {
    			    		tx.executeSql("update master_users set user_firstname = '"+ obj[x].FirstName +"', user_lastname = '"+ obj[x].LastName +"', user_password = '"+ obj[x].Password +"' , " +
    			    				"user_active = '1', user_id = '"+ obj[x].UserID +"' , user_vno = '"+ obj[x].VehicleNumber +"' , " +
    			    						"user_dchannel = '"+ obj[x].DistributionChannel +"', user_plant = '"+ obj[x].Plant +"'   where internal_id = '"+ obj[x].InternalID +"' ;", [], "" , errorCB);
    			    	});
    					
    				} else {
    					// insert 
    					
    					
						db.transaction(function(tx) {
				    		tx.executeSql("insert into master_users values ('" + obj[x].InternalID + "', '" + obj[x].UserID + "', '" + obj[x].Password + "', " +
				    				"'" + obj[x].FirstName + "', '" + obj[x].LastName + "', '1', '" + obj[x].DistributionChannel + "', " +
	    			    						"'" + obj[x].VehicleNumber + "', '" + obj[x].Plant + "') ;", [], "" , errorCB);
    			    	});
    					
    				}
    				
    				
				}

    		}

    	}	
    	
    	DownloadMasterDamages(); 
	}
	
	function CheckUserExist(user_internal_id) {
		
		var IsExist = false; 
		
		db.transaction(function(tx) {
    		tx.executeSql("select * from master_users where internal_id = '"+ user_internal_id +"' ;", [], function(tx, results) {	

    			if (results.rows.length > 0){			
    				IsExist = true;
    			} else {
    				IsExist = false
    			}
    		}
    		, errorCB);
    		
    	});
		
		
		return IsExist;

	}
	
	function CheckUserExist_querySuccess(tx, results) {	

		if (results.rows.length > 0){			
			return true;
		} else {
			return false
		}
	}
	
	function DownloadMasterDamages () {

		$.isLoading( "hide" );
		$('body').isLoading({ text: "Downloading Master Damage ..." });
		
		$.ajax ({
			type: "POST",
			url: url_src + "DownloadMasterDamagesByJSON",
			crossDomain: true,     
			data: "dtCreated=" + LastSyncDate,
			//data: "dtCreated=" + "07/07/2013",
			dataType: "xml",
			success: DownloadMasterDamagesSuccess,
			error: SyncError			
		});
	

	}


	function DownloadMasterDamagesSuccess (data, status) {

    	if (data != "") {
    		var xml = $(data).find("string").text();

    		// parse json
    		var obj = $.parseJSON (xml);
    		var sql = [];
			
    		if (obj.length > 0) {

    			$.isLoading( "hide" );
        		$('body').isLoading({ text: "Total Master Damage: " + obj.length });
    			
    			for (var x = 0; x < obj.length; x++) {

    				//sql[x] = "INSERT INTO master_damage VALUES ('" + obj[x].damage_code + "', '" + obj[x].damage_desc + "', '" + obj[x].damage_group + "');";
					// ACTUAL DATABASE INSERT!!!
    				if(CheckDamageExist(obj[x].damage_code, obj[x].damage_group)){
    					//update
    					db.transaction(function(tx) {
    			    		tx.executeSql("update master_damage set damage_desc = '"+ obj[x].damage_desc +"'" +
    			    				" where damage_code = '"+ obj[x].damage_code +"' and damage_group = '"+ obj[x].damage_group +"' ;", [], "" , errorCB);
    			    	});
    					
    				} else {
    					// insert 
    					db.transaction(function(tx) {
    			    		tx.executeSql("insert into master_damage values ('" + obj[x].damage_code + "', '" + obj[x].damage_desc + "', '" + obj[x].damage_group + "') ;", [], "" , errorCB);
    			    	});
    				}
    				
				}

    		}

    	}
    	
    	DownloadMasterCauses();
    	
	}
	
	function CheckDamageExist(damagecode, damagegrp) {
		
		var IsExist = false; 
		
		db.transaction(function(tx) {
    		tx.executeSql("select * from master_damage where damage_code = '"+ damagecode +"' and damage_group = '"+ damagegrp +"' ;", [], IsExist = CheckDamageExist_querySuccess , errorCB);
    	});
		
		return IsExist;
	}
	
	function CheckDamageExist_querySuccess(tx, results) {
		if (results.rows.length > 0){
			return true;
		} else {
			return false
		}
	}

	function DownloadMasterCauses () {
		
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Downloading Master Cause ..." });

		$.ajax ({
			type: "POST",
			url: url_src + "DownloadMasterCausesByJSON",
			crossDomain: true,     
			data: "dtCreated=" + LastSyncDate,
			//data: "dtCreated=" + "07/07/2013",
			dataType: "xml",
			success: DownloadMasterCausesSuccess,
			error: SyncError			
		});		

	}

	function DownloadMasterCausesSuccess (data, status) {

    	if (data != "") {
    		var xml = $(data).find("string").text();

    		// parse json
    		var obj = $.parseJSON (xml);
    		var sql = [];
			
    		if (obj.length > 0) {

    			$.isLoading( "hide" );
        		$('body').isLoading({ text: "Total Master Cause: " + obj.length });
    			
    			for (var x = 0; x < obj.length; x++) {

    				//sql[x] = "INSERT INTO master_cause VALUES ('" + obj[x].cause_code + "', '" + obj[x].cause_desc + "', '" + obj[x].cause_group + "');";
					// ACTUAL DATABASE INSERT!!!
    				
    				if(CheckCauseExist(obj[x].cause_code, obj[x].cause_group)){
    					//update
    					db.transaction(function(tx) {
    			    		tx.executeSql("update master_cause set cause_desc = '"+ obj[x].cause_desc +"'" +
    			    				" where cause_code = '"+ obj[x].cause_code +"' and cause_group = '"+ obj[x].cause_group +"' ;", [], "" , errorCB);
    			    	});
    					
    				} else {
    					// insert 
    					db.transaction(function(tx) {
    			    		tx.executeSql("insert into master_cause values ('" + obj[x].cause_code + "', '" + obj[x].cause_desc + "', '" + obj[x].cause_group + "') ;", [], "" , errorCB);
    			    	});
    				}


				}

    		}

    	}	
    	
    	UpdateLastSyncDate(); 
    	
	}

	function CheckCauseExist (causecode, causegrp) {
	
		var IsExist = false; 
		
		db.transaction(function(tx) {
    		tx.executeSql("select * from master_cause where cause_code = '"+ causecode +"' and cause_group = '"+ causegrp +"' ;", [], IsExist = CheckCauseExist_querySuccess , errorCB);
    	});
		
		return IsExist;
		
	}
	
	function CheckCauseExist_querySuccess() {
		if (results.rows.length > 0){
			return true;
		} else {
			return false
		}
	}
	
	function UpdateLastSyncDate() {
		
		var d = new Date(); 
		var month = ("0" + (d.getMonth() + 1)).slice(-2);
		var day = ("0" + d.getDate()).slice(-2);
		var year = d.getFullYear();	
		var h = d.getHours();
		var m = d.getMinutes();
		var s = d.getSeconds();
		
		var today_date =  year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;
		
		db.transaction(function(tx) {
    		tx.executeSql("delete from tmp_sync; ", [], "" , errorCB);
    	});
		
		db.transaction(function(tx) {
    		tx.executeSql("insert into tmp_sync values ('"+ today_date +"') ;", [], "" , errorCB);
    	});

		DownloadQuickNotes();
	}
	
	function DownloadQuickNotes () {

		$.isLoading( "hide" );
		$('body').isLoading({ text: "Downloading Quick Notes ..." });
		
		$.ajax ({
			type: "POST",
			url: url_src + "DownloadQuickNotes",
			crossDomain: true,     				
			dataType: "xml",
			success: DownloadQuickNotesSuccess,
			error: SyncError			
		});	

	}
	

	function DownloadQuickNotesSuccess (data, status) {
    	if (data != "") {
    		var xml = $(data).find("string").text();

    		// parse json
    		var obj = $.parseJSON (xml);
    		var sql = [];
			
    		if (obj.length > 0) {

    			for (var x = 0; x < obj.length; x++) {

    				sql[x] = "INSERT INTO master_quick_notes VALUES ('" + obj[x].internal_id + "', '" + obj[x].description + "', '" + obj[x].active + "', '" + obj[x].lang + "')";    				
					// ACTUAL DATABASE INSERT!!!
    				db.transaction(function(tx) {
    		    		tx.executeSql(sql[x], [], "" , errorCB);
    		    	});
				}
    		}
    	}
    	
    	DownloadMasterCheckListType();
	}

	function DownloadMasterCheckListType() {

		$.isLoading( "hide" );
		$('body').isLoading({ text: "Downloading Checklist Type ..." });
		
		$.ajax ({
			type: "POST",
			url: url_src + "DownloadMasterCheckListType",
			crossDomain: true,     				
			data: "dtCreated=" + LastSyncDate,
			dataType: "xml",
			success: DownloadMasterCheckListTypeSuccess,
			error: SyncError			
		});	

		
	}
	
	function DownloadMasterCheckListTypeSuccess(data, status) {
		if (data != "") {
    		var xml = $(data).find("string").text();

    		// parse json
    		var obj = $.parseJSON (xml);
    		var sql = [];
			
    		if(obj != null){
				if (obj.length > 0) {

	    			db.transaction(function(tx) {
			    		tx.executeSql("delete from master_checklist_type", [], "" , errorCB);
			    	});
	    			
	    			for (var x = 0; x < obj.length; x++) {

	    				sql[x] = "INSERT INTO master_checklist_type VALUES ( '" + obj[x].internal_id + "', '" + obj[x].type_name + "' )";    				
						// ACTUAL DATABASE INSERT!!!
	    				db.transaction(function(tx) {
	    		    		tx.executeSql(sql[x], [], "" , errorCB);
	    		    	});
					}

	    		}
			}
    		

    	}	
		
		DownloadMasterCheckList();
		
	}
	
	function DownloadMasterCheckList() {
		
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Downloading Checklist ..." });
		
		$.ajax ({
			type: "POST",
			url: url_src + "DownloadMasterCheckList",
			crossDomain: true,
			data: "dtCreated=" + LastSyncDate,
			dataType: "xml",
			success: DownloadMasterCheckListSuccess,
			error: SyncError			
		});	

	}
	
	function DownloadMasterCheckListSuccess (data, status) {
		if (data != "") {
    		var xml = $(data).find("string").text();

    		// parse json
    		var obj = $.parseJSON (xml);
    		var sql = [];
			
    		if(obj != null) {
				if (obj.length > 0) {

	    			db.transaction(function(tx) {
			    		tx.executeSql("delete from master_checklist", [], "" , errorCB);
			    	});
	    			
	    			for (var x = 0; x < obj.length; x++) {

	    				sql[x] = "INSERT INTO master_checklist VALUES ( '" + obj[x].internal_id + "', '" + obj[x].checklist_question.replace("'", "''") + "', '" + obj[x].checklist_active + "', '" + obj[x].checklist_type + "', '" + obj[x].checklist_seq + "' )";    				
						// ACTUAL DATABASE INSERT!!!
	    				db.transaction(function(tx) {
	    		    		tx.executeSql(sql[x], [], "" , errorCB);
	    		    	});
					}

	    		}
			}
    		

    	}	
		
		DownloadMasterCheckListRelation();
				
	}
	
	function DownloadMasterCheckListRelation() {
		
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Downloading CheckList Relation ..." });
		
		$.ajax ({
			type: "POST",
			url: url_src + "DownloadMasterCheckListRelation",
			crossDomain: true,     				
			dataType: "xml",
			success: DownloadMasterCheckListRelationSuccess,
			error: SyncError			
		});	

	}
	
	function DownloadMasterCheckListRelationSuccess(data, status) {
		
		if (data != "") {
    		var xml = $(data).find("string").text();

    		// parse json
    		var obj = $.parseJSON (xml);
    		var sql = [];
			
    		if (obj.length > 0) {

    			db.transaction(function(tx) {
		    		tx.executeSql("delete from master_checklist_relation", [], "" , errorCB);
		    	});
    			
    			for (var x = 0; x < obj.length; x++) {

    				sql[x] = "INSERT INTO master_checklist_relation VALUES ( '" + obj[x].checklist_type + "', '" + obj[x].dchannel + "', '" + obj[x].plant + "' )";    				
					// ACTUAL DATABASE INSERT!!!
    				db.transaction(function(tx) {
    		    		tx.executeSql(sql[x], [], "" , errorCB);
    		    	});
				}

    		}

    	}	

		DownloadOpNotification(current_login.user_id );
	}
	

	function DownloadOpNotification (str_employeeid) {


			employee_id = str_employeeid;
			
			//ShowStatus ("Downloading Notification...");
			$.isLoading( "hide" );
			$('body').isLoading({ text: "Downloading Notification..." });

			$.ajax ({
				type: "POST",
				url: url_src + "DownloadOpnotificationFromSQL",
				crossDomain: true,     
				data: "EmployeeID=" + employee_id,
				dataType: "xml",
				success: DownloadOpNotificationSuccess,
				error: SyncError

			});

	}


	function DownloadOpNotificationSuccess (data, status) {
	
			try{
		    	if (data != "") {
		    		var xml = $(data).find("string").text();
		    		
		    		// parse json
		    		obj_array_notifications = $.parseJSON (xml);

		    		
		    		
		    		
		    		if (obj_array_notifications.length > 0) {    			
		    			
		    			//ShowStatus ("Total Notifications: " + obj_array_notifications.length);
		    			$.isLoading( "hide" );
		    			$('body').isLoading({ text: "Total Notifications: " + obj_array_notifications.length });
		    			
						if (ClearOpNotifications()) {
							
							//ShowStatus ("Inject Notifications");
							$.isLoading( "hide" );
			    			$('body').isLoading({ text: "Inject Notifications" });
			    						    			
							InjectOpNotification(obj_array_notifications);
	
							array_notifications = [];
							
							DownloadOpTimeline(employee_id);
						}
		    		} else {
		    			ClearOpNotifications();
		    			$.isLoading( "hide" );
		    		}
		    		
	
		    	} else {
	    			$.isLoading( "hide" );
	    		}
			} catch(e){
				//alert(e);
				$.isLoading( "hide" );
			}
		
	}
	
	function DownloadOpTimeline (employeeid) {
		$.ajax ({
			type: "POST",
			url: url_src + "DownloadOpTimelineFromSQL",
			crossDomain: true,     
			data: "EmployeeID=" + employee_id,
			dataType: "xml",
			success: DownloadOpTimelineSuccess,
			error: SyncError

		});

	}	

	
	function DownloadOpTimelineSuccess (employeeid) {
				
		//ShowStatus ("Downloading Timeline...");
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Downloading Timeline..." });
		
		$.ajax ({

			type: "POST",
			url: url_src + "DownloadOpTimelineFromSQL",
			crossDomain: true,     
			data: "EmployeeID=" + employee_id,
			dataType: "xml",
			success: DownloadOpTimelineSuccess,
			error: SyncError

		});

	}	


	function DownloadOpTimelineSuccess (data, status) {
		

    	if (data != "") {
    		var xml = $(data).find("string").text();
    		
    		// parse json
    		obj_array_timelines = $.parseJSON (xml);

    		if (obj_array_timelines.length > 0) {    			
    			
    			//ShowStatus ("Total Timeline: " + obj_array_timelines.length);
    			$.isLoading( "hide" );
    			$('body').isLoading({ text: "Total Timeline: " + obj_array_timelines.length });
    			
				if (ClearTimeline()) {
					// display message: Loading notifications...
					InjectOpTimeline(obj_array_timelines);

					//$.isLoading( "hide" );
					//array_notifications=[];
					//LoadNotifications();
					
					DownloadOpDamages(employee_id);
					
					
				}
    		}
    		else {
    			DownloadOpDamages(employee_id);
    		}


    	}

	}
	

	function DownloadOpDamages (employeeid) {

		//ShowStatus ("Downloading Damages...");
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Downloading Damages..." });
		
		
		$.ajax ({

			type: "POST",
			url: url_src + "DownloadDamagesFromSQL",
			crossDomain: true,     
			data: "EmployeeID=" + employee_id,
			dataType: "xml",
			success: DownloadOpDamagesSuccess,
			error: SyncError

		});		
	}

	function DownloadOpDamagesSuccess (data, status) {

		
    	if (data != "") {
    		
    		var xml = $(data).find("string").text();
    		
    		// parse json
    		obj_array_damages = $.parseJSON (xml);

    		
    		if (obj_array_damages.length > 0) {    			
    			
    			//ShowStatus ("Total Damages: " + obj_array_damages.length);
    			$.isLoading( "hide" );
    			$('body').isLoading({ text: "Total Damages: " + obj_array_damages.length });
    			
    			
				if (ClearOpDamages()) {
					// display message: Loading notifications...
					InjectOpDamages(obj_array_damages);

					DownloadOpCauses(employee_id);
				}
    		}
    		 else{
    	    		DownloadOpCauses(employee_id);
    		 }


    	} else{
    		DownloadOpCauses(employee_id);
    	}

	}

	function DownloadOpCauses (employeeid) {

		//ShowStatus ("Downloading Causes...");
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Downloading Causes..." });
		
		$.ajax ({

			type: "POST",
			url: url_src + "DownloadCausesFromSQL",
			crossDomain: true,     
			data: "EmployeeID=" + employee_id,
			dataType: "xml",
			success: DownloadOpCausesSuccess,
			error: SyncError

		});		
	}	


	function DownloadOpCausesSuccess (data, status) {

    	if (data != "") {
    		var xml = $(data).find("string").text();
    		// parse json
    		obj_array_causes = $.parseJSON (xml);

			//ShowStatus ("Total Causes: " + obj_array_causes.length);
			$.isLoading( "hide" );
			$('body').isLoading({ text: "Total Causes: " + obj_array_causes.length });
			
    		if (obj_array_causes.length > 0) {    			    		    			

				if (ClearOpCauses()) {
					// display message: Loading notifications...
					
					InjectOpCauses(obj_array_causes);

					DownloadOpParts(employee_id);
				}
    		}else {
        		DownloadOpParts(employee_id);
        	}


    	} else {
    		DownloadOpParts(employee_id);
    	}

	}


	function DownloadOpParts (employeeid) {

		//ShowStatus ("Downloading Parts...");
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Downloading Parts by engineer..." });
				
		$.ajax ({

			type: "POST",
			url: url_src + "DownloadOpPartByEngineerFromSQL",
			crossDomain: true,     
			data: "EmployeeID=" + employee_id,
			dataType: "xml",
			success: DownloadOpPartsSuccess,
			error: SyncError

		});		
		
	}	


	function DownloadOpPartsSuccess (data, status) {
		

    	if (data != "") {
    		var xml = $(data).find("string").text();
    		
    		// parse json
    		obj_array_parts = $.parseJSON (xml);

			//ShowStatus ("Total Parts: " + obj_array_parts.length);
			$.isLoading( "hide" );
			$('body').isLoading({ text: "Total Parts: " + obj_array_parts.length });
			

    		if (obj_array_parts.length > 0) {    			    		    			

				if (ClearOParts()) {
					// display message: Loading notifications...
					InjectOpParts(obj_array_parts);
					
					DownloadOpVanPart(employee_id);
					//SyncComplete();
				}
    		} else {
    			DownloadQuotationHeader(employee_id);
    			//SyncComplete();
    		}


    	} else {
    		DownloadQuotationHeader(employee_id);
    	}

	}	
	
	function DownloadOpVanPart(employee_id) {

		
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Downloading..." });
				
		$.ajax ({

			type: "POST",
			url: url_src + "DownloadOpVanPartFromSQL",
			crossDomain: true,     
			//temp command off IMPORTANT TO COMMAND BACK!
			data: "VehicleID=" + current_login.user_vno  + "&TargettedDate=" + date_to ,
			//data: "VehicleID=" + current_login.user_vno  + "&TargettedDate=2014-09-23",
			dataType: "xml",
			success: DownloadOpVanPartSuccess,
			error: SyncError
			

		});	
		
	}
	
	function DownloadOpVanPartSuccess (data, status) {
		

    	if (data != "") {
    		var xml = $(data).find("string").text();
    		// parse json
    		obj_array_van_parts = $.parseJSON (xml);
    				
    		if (obj_array_van_parts != null) {
				
				$.isLoading( "hide" );
				$('body').isLoading({ text: "Total Van Parts: " + obj_array_van_parts.length });

				if (obj_array_van_parts.length > 0) {    			    		    			
	    			if (ClearOpVanPart()) { 
	    				
	    				InjectOpVanPart(obj_array_van_parts);

	    			}
	    		}
			}

    	}
    	
    	DownloadQuotationHeader(employee_id); 
    	// SyncComplete();
		
	}
	
	function DownloadQuotationHeader(employeeid){

		$.isLoading( "hide" );
		$('body').isLoading({ text: "Downloading quotation header..." });
				
		$.ajax ({

			type: "POST",
			url: url_src + "DownloadQuotationHeader",
			crossDomain: true,     
			data: "EmployeeID=" + employee_id,
			dataType: "xml",
			success: DownloadQuotationHeaderSuccess,
			error: SyncError

			
		});		
	}

	function DownloadQuotationHeaderSuccess(data, status){
		
    	if (data != "") {

    		var xml = $(data).find("string").text();

    		// parse json
    		obj_array_quotation_header = $.parseJSON (xml);
    		
    		if (obj_array_quotation_header != null) {
				
				$.isLoading( "hide" );
				$('body').isLoading({ text: "Total quotation header: " + obj_array_quotation_header.length });

				if (obj_array_quotation_header.length > 0) {    			    		    			
	    			if (ClearOpQuatationHeader()) { 
	    				InjectOpQuotationHeader(obj_array_quotation_header);
	    				DownloadQuotationDetail(employee_id);
	    			}
	    		}
				else{
					DownloadMessage(employee_id); 
				}
				//SyncComplete();
				//DownloadMessage(employee_id); 
			}

    	} else {
    		 //SyncComplete();
    		DownloadMessage(employee_id); 
    	}
    	
    	
    	
	}
	
	function DownloadQuotationDetail(employeeid){
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Downloading quotation detail..." });
				
		$.ajax ({

			type: "POST",
			url: url_src + "DownloadQuotationDetail",
			crossDomain: true,     
			data: "EmployeeID=" + employee_id,
			dataType: "xml",
			success: DownloadQuotationDetailSuccess,
			error: SyncError

		});		
	}
	
	function DownloadQuotationDetailSuccess(data, status){
		
		if (data != "") {
    		var xml = $(data).find("string").text();
    		// parse json
    		obj_array_quotation_detail = $.parseJSON (xml);
    				
    		if (obj_array_quotation_header != null) {
				
				$.isLoading( "hide" );
				$('body').isLoading({ text: "Total quotation detail: " + obj_array_quotation_detail.length });

				if (obj_array_quotation_detail.length > 0) {    			    		    			
	    			if (ClearOpQuatationDetail()) { 
	    				
	    				InjectOpQuotationDetail(obj_array_quotation_detail);
	    				
	    				DownloadMessage(employee_id); 
	    				
	    				///command off on 20151114
	    				///SyncComplete();
	    			}
	    		}
			}

    	} else {
    		DownloadMessage(employee_id); 
    		 //SyncComplete();
    	}

	}
	
	
	function DownloadMessage(employee_id){
		
		$.isLoading( "hide" );
		$('body').isLoading({ text: "Downloading message..." });
				
		$.ajax ({

			type: "POST",
			url: url_src + "DownloadOpMessageByEngineerFromSQL",
			crossDomain: true,     
			data: "EmployeeID=" + employee_id,
			dataType: "xml",
			success: DownloadMessageSuccess,
			error: SyncError

		});		
	}
	
	function DownloadMessageSuccess(data, status){
		
		
		
		if (data != "") {
    		var xml = $(data).find("string").text();
    		// parse json
    		obj_array_message = $.parseJSON (xml);
    				
    		if (obj_array_message != null) {
				
				$.isLoading( "hide" );
				$('body').isLoading({ text: "Total message: " + obj_array_message.length });

				if (obj_array_message.length > 0) {    			    		    			
	    			if (ClearMessage()) { 
	    				
	    				InjectMessage(obj_array_message);
	    				
	    				SyncComplete();
	    			}
	    		} else{
	    			SyncComplete();
	    		}
			} else{
				SyncComplete();
			}

    	} else {
    		
    		 SyncComplete();
    	}

		
	}

	
	function InjectMessage(obj_array){

		var smooth = false;
		var sql = "";

		for (var x = 0; x < obj_array.length; x++) {

			sql = "INSERT INTO op_message (internal_id, engineer_id, msg_text, msg_date, msg_isread) VALUES (";
			sql += "'" + obj_array[x].InternalID + "',";		
			sql += "'" + obj_array[x].Engineer.InternalID + "',";
			sql += "'" + obj_array[x].MsgText + "',";
			sql += "'" + obj_array[x].MsgDate + "',";
			if(obj_array[x].IsRead == false){
				sql += "'0'";
			}
			else {
				sql += "'1'";
			}

			sql += ");";
			
			db.transaction(function(tx) {
	    		tx.executeSql(sql, [], function(){smooth = true}, errorCB);
	    	});
			
		}

		return smooth;
		
	}
	
	function SyncComplete () {
		// do something
		//ShowStatus ("Sync sucessfully completed");

		$.isLoading( "hide" );
		$('body').isLoading({ text: "Sync sucessfully completed" });
		
		array_notifications=[];
		LoadNotifications();
		LoadDashboard();
		
		if (SelectedNotificationID != "") { 
			LoadNotificationDetail(current_notification.internal_id);
		}
		$.isLoading( "hide" );
		
		//window.location.reload();
		
	}	
	
	
	
	
	
	
	
	
	
	


	
	
	
	
	
	
	
	
	
	
	
	//////// Inject Data to database  ///////

	function InjectOpNotification (obj_array) {

		var smooth = false;
		var sql = "";
		var sql2 = "";
		var sql3 = "";
		
		
		var d = new Date(); 
		var month = ("0" + (d.getMonth() + 1)).slice(-2);
		var day = ("0" + d.getDate()).slice(-2);
		var year = d.getFullYear();	
		var h = d.getHours();
		var m = d.getMinutes();
		var s = d.getSeconds();
		  
		var today_date = ("0" + d.getDate()).slice(-2) + ("0" + (d.getMonth() + 1)).slice(-2) +  d.getFullYear() + h + m ;
		var quotation_date =  year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;
		
		for (var x = 0; x < obj_array.length; x++) {

			sql = "INSERT INTO op_notification (internal_id, notification_subject, notification_typeid, notification_activityid, notification_no, notification_so, notification_soldtoid, notification_shiptoid, notification_status, notification_priority, notification_equipment, notification_objnr, notification_aufnr, notification_signby, notification_signbydisgn, notification_signbydept, notification_signbycontact, notification_signbyic, notification_requiredstart, notification_requiredtime, notification_resp, notification_sapready, notification_operator) VALUES (";
			sql += "'" + obj_array[x].internal_id + "',";
			sql += "'" + obj_array[x].notification_subject.replace("'", "''") + "',";
			sql += "'" + obj_array[x].notification_typeid + "',";
			sql += "'" + obj_array[x].notification_activityid + "',";
			sql += "'" + obj_array[x].notification_no + "',";
			sql += "'" + obj_array[x].notification_so + "',";
			sql += "'" + obj_array[x].notification_soldtoid + "',";
			sql += "'" + obj_array[x].notification_shiptoid + "',";
			sql += "'" + obj_array[x].notification_status + "',";
			sql += "'" + obj_array[x].notification_priority + "',";
			sql += "'" + obj_array[x].notification_equipment + "',";
			sql += "'" + obj_array[x].notification_objnr + "',";
			sql += "'" + obj_array[x].notification_aufnr + "',";
			sql += "'" + EnableNull(obj_array[x].notification_signby) + "',";
			sql += "'" + EnableNull(obj_array[x].notification_signbydisgn) + "',";
			sql += "'" + EnableNull(obj_array[x].notification_signbydept) + "',";
			sql += "'" + EnableNull(obj_array[x].notification_signbycontact) + "',";
			sql += "'" + EnableNull(obj_array[x].notification_signbyic) + "',";
			
			var d = new Date(obj_array[x].notification_requiredstart); 
			var month = ("0" + (d.getMonth() + 1)).slice(-2);
			var day = ("0" + d.getDate()).slice(-2);
			var year = d.getFullYear();	
			var h = d.getHours();
			var m = d.getMinutes();
			var s = d.getSeconds();
			  
			var notification_requiredstart =  year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;
			
			
			//sql += "'" + obj_array[x].notification_requiredstart + "',";
			sql += "'" + notification_requiredstart + "',";

			sql += "'" + obj_array[x].notification_requiredtime + "',";
			sql += "'" + obj_array[x].notification_resp + "',";
			sql += "'" + obj_array[x].notification_sapready + "',";
			sql += "'" + obj_array[x].notification_operator + "'";			
			sql += ");";
			
			sql2 = "insert into master_customers (cust_customer, cust_incoterms2, cust_name1, cust_name2, cust_city, cust_po, cust_division, cust_street, cust_tel1, cust_fax, cust_salesorg, cust_distrchannel, cust_currency, cust_peymentterms) values (";
			sql2 += "'" + obj_array[x].CurCust.InternalID + "',";
			sql2 += "'" + obj_array[x].CurCust.Incoterms2 + "',";
			sql2 += "'" + obj_array[x].CurCust.Name1.replace("'", "''") + "',";
			sql2 += "'" + obj_array[x].CurCust.Name2.replace("'", "''") + "',";
			sql2 += "'" + obj_array[x].CurCust.City.replace("'", "''") + "',";
			sql2 += "'" + obj_array[x].CurCust.PO + "',";
			sql2 += "'" + obj_array[x].CurCust.Division.replace("'", "''") + "',";
			sql2 += "'" + obj_array[x].CurCust.Street.replace("'", "''") + "',";
			sql2 += "'" + obj_array[x].CurCust.Tel1 + "',";
			sql2 += "'" + obj_array[x].CurCust.Fax + "',";
			sql2 += "'" + obj_array[x].CurCust.SalesOrg + "',";
			sql2 += "'" + obj_array[x].CurCust.DistrChannel + "',";
			sql2 += "'" + obj_array[x].CurCust.Currency + "',";
			sql2 += "'" + obj_array[x].CurCust.PaymentTerm.InternalID + "' ";
			sql2 += ");";

			
			
			sql3 = "insert into master_equipment (equipment_desc, equipment_snr, equipment_obj, equipment_location, equipment_profile, equipment_id ) values (";
			sql3 += "'" + obj_array[x].CurEquip.Description + "',";
			sql3 += "'" + obj_array[x].CurEquip.EquipmentSNR + "',";
			sql3 += "'" + obj_array[x].CurEquip.EquipmentObject + "',";
			sql3 += "'" + obj_array[x].CurEquip.EquipmentLocation + "',";
			sql3 += "'" + obj_array[x].CurEquip.EquipmentProfileID + "',";
			sql3 += "'" + obj_array[x].CurEquip.InternalID + "' ";
			sql3 += ");";
			

			db.transaction(function(tx) {
	    		tx.executeSql(sql, [], function(){smooth = true}, errorCB);
	    	});
			
			db.transaction(function(tx) {
	    		tx.executeSql(sql2, [], function(){smooth = true}, errorCB);
	    	});
			
			db.transaction(function(tx) {
	    		tx.executeSql(sql3, [], function(){smooth = true}, errorCB);
	    	});
			
			
			
		}

		//if (true) {
		//	smooth = true;
		//}		
		
		//smooth = true;

		return smooth;
	}

	function InjectOpTimeline (obj_array) {

		var smooth = false;
		var sql = "";

		for (var x = 0; x < obj_array.length; x++) {

			sql = "INSERT INTO op_timestamp (internal_id, tstamp_notification, job_date, job_travel, job_waiting, job_travel_start, job_travel_end, job_waiting_start, job_waiting_end, job_start, job_end, job_description, job_status, job_by, op_updated_from_sap, op_shared) VALUES (";
			sql += "'" + obj_array[x].internal_id + "',";			
			sql += "'" + obj_array[x].tstamp_notification + "',";
			
			if(obj_array[x].job_date.length > 0) {
				sql += "'" + ConvertDate(obj_array[x].job_date) + "',";
				
			} else {
				sql += EnableNull(obj_array[x].job_date) + ",";
			}

			if(obj_array[x].job_travel.length > 0) {
				sql += "'" + obj_array[x].job_travel + "',";
				
			} else {
				sql += EnableNull(obj_array[x].job_travel) + ",";
			}
			
			if(obj_array[x].job_waiting.length > 0) {
				sql += "'" + obj_array[x].job_waiting + "',";
				
			} else {
				sql += EnableNull(obj_array[x].job_waiting) + ",";
			}
			
			if(obj_array[x].job_travel_start.length > 0) {
				sql += "'" + ConvertDate(obj_array[x].job_travel_start) + "',";
				
			} else {
				sql += EnableNull(obj_array[x].job_travel_start) + ",";
			}

			if(obj_array[x].job_travel_end.length > 0) {
				sql += "'" + ConvertDate(obj_array[x].job_travel_end) + "',";
				
			} else {
				sql += EnableNull(obj_array[x].job_travel_end) + ",";
			}
			
			if(obj_array[x].job_waiting_start.length > 0) {
				sql += "'" + ConvertDate(obj_array[x].job_waiting_start) + "',";
				
			} else {
				sql += EnableNull(obj_array[x].job_waiting_start) + ",";
			}
			
			if(obj_array[x].job_waiting_end.length > 0) {
				sql += "'" + ConvertDate(obj_array[x].job_waiting_end) + "',";
				
			} else {
				sql += EnableNull(obj_array[x].job_waiting_end) + ",";
			}
			if(obj_array[x].job_start.length > 0) {
				sql += "'" + ConvertDate(obj_array[x].job_start) + "',";
				
			} else {
				sql += EnableNull(obj_array[x].job_start) + ",";
			}
			
			if(obj_array[x].job_end.length > 0) {
				sql += "'" + ConvertDate(obj_array[x].job_end) + "',";
				
			} else {
				sql += EnableNull(obj_array[x].job_end) + ",";
			}

			sql += "'" + obj_array[x].job_description.replace("'", "''") + "',";			
			sql += "'" + obj_array[x].job_status + "',";			
			sql += "'" + obj_array[x].job_by + "',";			
			sql += "'1',";	

			if(obj_array[x].op_shared==null){
				sql += "'0'";
				
			} else {
				sql += "'1'";
			}
			sql += ");";

			db.transaction(function(tx) {
	    		tx.executeSql(sql, [], function(){smooth = true}, errorCB);
	    	});
			
		}

		
		return smooth;
	}	
	
	function InjectOpDamages (obj_array) {

		var smooth = false;
		var sql = "";

		//for (var x = 0; x < 2; x++) {
		for (var x = 0; x < obj_array.length; x++) {

			sql = "INSERT INTO op_damages (internal_id, damage_notification, damage_group, damage_code, damage_desc, damage_order, op_sys) VALUES ( ";
			sql += "'" + obj_array[x].internal_id + "',";			
			sql += "'" + obj_array[x].damage_notification + "',";			
			sql += "'" + obj_array[x].damage_group + "',";			
			sql += "'" + obj_array[x].damage_code + "',";			
			sql += "'" + obj_array[x].damage_desc + "',";			
			sql += "'" + obj_array[x].damage_order + "',";						
			sql += "'1'";						
			sql += ");";

			db.transaction(function(tx) {
	    		tx.executeSql(sql, [], function(){smooth = true}, errorCB);
	    	});
		}

		//if (true) {
		//	smooth = true;
		//}		

		return smooth;
	}	

	function InjectOpCauses (obj_array) {

		var smooth = false;
		var sql = "";

		for (var x = 0; x < obj_array.length; x++) {

			sql = "INSERT INTO op_causes (internal_id, cause_notification, cause_group, cause_code, cause_desc, cause_order, op_sys) VALUES (";
			sql += "'" + obj_array[x].internal_id + "',";			
			sql += "'" + obj_array[x].cause_notification + "',";			
			sql += "'" + obj_array[x].cause_group + "',";			
			sql += "'" + obj_array[x].cause_code + "',";			
			sql += "'" + obj_array[x].cause_desc + "',";			
			sql += "'" + obj_array[x].cause_order + "',";		
			sql += "'1'";							
			sql += ");";
			
			db.transaction(function(tx) {
	    		tx.executeSql(sql, [], function(){smooth = true}, errorCB);
	    	});
			
		}

		//if (true) {
		//	smooth = true;
		//}		

		return smooth;
	}		

	function InjectOpParts (obj_array) {

		var smooth = false;
		var sql = "";

		for (var x = 0; x < obj_array.length; x++) {

			sql = "INSERT INTO op_parts (internal_id, part_notification, part_no, part_quantity, part_unit, part_consumption, part_material, part_material_desc, part_inuse, part_preset, op_sys, part_consumed, op_consumed_from_mobile, op_consumed_from_sap, op_updated_from_mobile, op_updated_from_sap, part_reserved, part_vehicleno) VALUES (";
			sql += "'" + obj_array[x].internal_id + "',";		
			sql += "'" + obj_array[x].part_notification + "',";		
			sql += "'" + obj_array[x].part_no + "',";		
			sql += "'" + obj_array[x].part_quantity + "',";		
			sql += "'" + obj_array[x].part_unit + "',";		
			sql += "'" + obj_array[x].part_consumption + "',";		
			sql += "'" + obj_array[x].part_material + "',";		
			sql += "'" + obj_array[x].part_material_desc + "',";		
			sql += "'" + obj_array[x].part_inuse + "',";		
			sql += "'" + obj_array[x].part_preset + "',";		
			sql += "'" + obj_array[x].op_sys + "',";		
			sql += "'" + obj_array[x].part_consumed + "',";		
			sql += "'" + obj_array[x].op_consumed_from_mobile + "',";		
			sql += "'" + obj_array[x].op_consumed_from_sap + "',";		
			sql += "'" + obj_array[x].op_updated_from_mobile + "',";		
			sql += "'" + obj_array[x].op_updated_from_sap + "',";		
			sql += "'" + obj_array[x].part_reserved + "',";		
			sql += "'" + obj_array[x].part_vehicleno + "'";					
			sql += ");";
			
			db.transaction(function(tx) {
	    		tx.executeSql(sql, [], function(){smooth = true}, errorCB);
	    	});
			
		}

		//if (true) {
		//	smooth = true;
		//}		

		return smooth;
	}	

	function InjectOpVanPart (obj_array) {
		
		var smooth = false;
		var sql = "";

		for (var x = 0; x < obj_array.length; x++) {

			sql = "INSERT INTO op_parts_vehicle (part_id,part_id_old,part_desc,part_avail,part_reserved,part_consumed,part_uom,part_vehicleid,part_date) VALUES (";
			sql += "'" + obj_array[x].part_id + "',";		
			sql += "'" + obj_array[x].part_id_old + "',";		
			sql += "'" + obj_array[x].part_desc + "',";		
			sql += "'" + obj_array[x].part_avail + "',";		
			sql += "'" + obj_array[x].part_reserved + "',";		
			sql += "'" + obj_array[x].part_consumed + "',";		
			sql += "'" + obj_array[x].part_uom + "',";		
			sql += "'" + current_login.user_vno + "',";		
			sql += "'" + obj_array[x].part_date + "'";		
			sql += ");";
			
			db.transaction(function(tx) {
	    		tx.executeSql(sql, [], function(){smooth = true}, errorCB);
	    	});
			
		}

		return smooth;
		
	}
	
	
	function InjectOpQuotationHeader (obj_array) {
		
		var smooth = false;
		var sql = "";

		for (var x = 0; x < obj_array.length; x++) {

			sql = "INSERT INTO op_quotation (internal_id,quotation_notification,quotation_no,quotation_notice,quotation_userstatus,quotation_validfrom,quotation_validto,quotation_engineer,quotation_status,quotation_currency,quotation_incoterm1,quotation_incoterm2,quotation_paymentterm,quotation_deliveryterm,quotation_attn,quotation_fax_email,quotation_date,quotation_customer_name,quotation_customer_address,quotation_validity, quotation_isdownloaded) VALUES (";
			sql += "'" + obj_array[x].InternalID + "',";		
			sql += "'" + obj_array[x].Notification.InternalID + "',";		
			sql += "'" + obj_array[x].QuotationNo + "',";		
			sql += "'" + obj_array[x].Notice + "',";		
			sql += "'" + obj_array[x].UserStatus + "',";		
			sql += "'',";		
			sql += "'',";		
			sql += "'" + obj_array[x].Engineer + "',";		
			sql += "'" + obj_array[x].Status + "',";
			sql += "'" + obj_array[x].Currency + "',";
			sql += "'" + obj_array[x].Incoterms1.InternalID + "',";
			sql += "'" + obj_array[x].Incoterm2 + "',";
			sql += "'" + obj_array[x].PaymentTerm.InternalID + "',";
			sql += "'" + obj_array[x].DeliveryTerm + "',";
			sql += "'" + obj_array[x].Attn + "',";
			sql += "'" + obj_array[x].FaxEmail + "',";
			//sql += "'" + obj_array[x].QuoteDate + "',";
			sql += "'" + ConvertDate(obj_array[x].QuoteDate) + "',";
			
			sql += "'" + obj_array[x].CustomerName + "',";
			sql += "'" + obj_array[x].CustomerAddress + "',";
			sql += "'" + obj_array[x].ValidityDays + "',";
			sql += "'1'";
			
			sql += ");";
			
			db.transaction(function(tx) {
	    		tx.executeSql(sql, [], function(){smooth = true}, errorCB);
	    	});
			
		}

		return smooth;
		
	}

	function InjectOpQuotationDetail (obj_array) {
		
		var smooth = false;
		var sql = "";

		for (var x = 0; x < obj_array.length; x++) {

			sql = "INSERT INTO op_quotation_detail (internal_id,detail_no,detail_quotation,detail_description,detail_quantity,detail_unit,detail_rate,detail_discount,detail_partno,detail_total_price) VALUES (";
			sql += "'" + obj_array[x].InternalID + "',";		
			sql += "'" + obj_array[x].DetailNo + "',";
			sql += "'" + obj_array[x].Quotation.InternalID + "',";
			sql += "'" + obj_array[x].Description + "',";
			sql += "'" + obj_array[x].Quantity + "',";
			sql += "'" + obj_array[x].Unit + "',";
			sql += "'" + obj_array[x].Rate + "',";
			sql += "'" + obj_array[x].Discount + "',";
			sql += "'" + obj_array[x].PartNo + "',";
			sql += "'" + obj_array[x].TotalPrice + "'";

			sql += ");";
			
			db.transaction(function(tx) {
	    		tx.executeSql(sql, [], function(){smooth = true}, errorCB);
	    	});
			
		}

		return smooth;
		
	}
	
	
	
	
	
	function ConvertDate(strdate){

		var d = new Date(strdate); 
		var month = ("0" + (d.getMonth() + 1)).slice(-2);
		var day = ("0" + d.getDate()).slice(-2);
		var year = d.getFullYear();	
		var h = d.getHours();
		var m = d.getMinutes();
		var s = d.getSeconds();
		  
		var newdate =  year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;
		
		return newdate;
		
	}
	
	
	
	
	
	
	
	
	


	//////// End Of Inject Data ///////
	
	
	//////// Clear Data Process  ///////
	
	function ClearOpNotifications () {

		var smooth = false;
		//var sql = "DELETE FROM op_notification; DELETE FROM master_customers; DELETE FROM master_equipment; ";

		//alert(sql); 
		//smooth = true;
		
		db.transaction(function(tx) {
    		tx.executeSql("DELETE FROM op_notification;", [], function(){smooth = true}, errorCB);
    	});
		
		db.transaction(function(tx) {
    		tx.executeSql("DELETE FROM master_customers;", [], function(){smooth = true}, errorCB);
    	});
		
		db.transaction(function(tx) {
    		tx.executeSql("DELETE FROM master_equipment;", [], function(){smooth = true}, errorCB);
    	});
		
		return smooth;
	}
	
	function ClearTimeline () {

		
		var smooth = false;
		var sql = "DELETE FROM op_timestamp";

		db.transaction(function(tx) {
    		tx.executeSql(sql, [], function(){smooth = true}, errorCB);
    	});
		
		//if (true) {
		//	smooth = true;
		//}

		return smooth;
	}		

	function ClearOpDamages () {

		var smooth = false;
		var sql = "DELETE FROM op_damages";

		db.transaction(function(tx) {
    		tx.executeSql(sql, [], function(){smooth = true}, errorCB);
    	});
		
		
		//if (true) {
		//	smooth = true;
		//}		

		return smooth;
	}	

	function ClearOpCauses () {

		var smooth = false;
		var sql = "DELETE FROM op_causes";		

		db.transaction(function(tx) {
    		tx.executeSql(sql, [], function(){smooth = true}, errorCB);
    	});
		
		
		//if (true) {
		//	smooth = true;
		//}		

		return smooth;
	}
	
	function ClearOParts () {

		var smooth = false;
		var sql = "DELETE FROM op_parts";

		db.transaction(function(tx) {
    		tx.executeSql(sql, [], function(){smooth = true}, errorCB);
    	});
		
		//if (true) {
		//	smooth = true;
		//}		

		return smooth;
	}			

	function ClearOpVanPart () {
		
		var smooth = false;
		var sql = "DELETE FROM op_parts_vehicle";

		db.transaction(function(tx) {
    		tx.executeSql(sql, [], function(){smooth = true}, errorCB);
    	});
		
		//if (true) {
		//	smooth = true;
		//}		

		return smooth;
		
	}
	
	function ClearOpQuatationHeader () {
		
		var smooth = false;
		var sql = "DELETE FROM op_quotation where quotation_status = '1'";

		db.transaction(function(tx) {
    		tx.executeSql(sql, [], function(){smooth = true}, errorCB);
    	});
		
		

		return smooth;
		
	}
	
	
	function ClearOpQuatationDetail () {
		
		var smooth = false;
		var sql = "DELETE FROM op_quotation_detail where detail_quotation not in (select internal_id from op_quotation) ";

		db.transaction(function(tx) {
    		tx.executeSql(sql, [], function(){smooth = true}, errorCB);
    	});
		
		

		return smooth;
		
	}
	
	function ClearMessage () {
		
		var smooth = false;
		//var sql = "DELETE FROM op_message where msg_isread = '1' and msg_arrival_date > ( select dt_last_sync from tmp_sync)";
		var sql = "DELETE FROM op_message where msg_isread = '1' and engineer_id = '"+ current_login.user_id +"' ";

		db.transaction(function(tx) {
    		tx.executeSql(sql, [], function(){smooth = true}, errorCB);
    	});
		
		

		return smooth;
		
	}
	
	
	
	//////// End Of Clear Data Process  ///////
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	

	
	
	
	
	
	// Database operation

	function EnableNull (str) {
		var result = "";

		if (str == "") {
			result = "NULL";
		} else {
			str = "'" + str + "'";
		}

		return result;

	}
	
	