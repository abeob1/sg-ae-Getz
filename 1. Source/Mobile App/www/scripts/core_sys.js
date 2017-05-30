///Swordfish v3.0.13 - timeline desc add 


var android_version = "Getz v3";
var SelectedStatus = "";
var shortby = "";
var current_notification = null;        // current notification showing detail
var current_timeline = null;            // current un-complete timeline
var current_login = null;               // current login engineer
var current_damages = null;
var current_part = [];
var date_to = "";
var TimelineStarted = false; 			//bool
var TimelineStarted_notification_no = "";
var TimelineStarted_notificationid = "";
var current_tstamp_id = "";
var SelectedCheckListHeaderID = ""; 
var SelectedQuotationInternalID = "";
var countofaddquote = 0;

var SelectedDamageGroup = null, SelectedCauseGroup = null; 
var CurEditDamageID = "", CurEditDamageCode ="", CurEditCauseID = "", CurEditCauseCode = "", selected_partid = "" ; 
var SelectedTimelineID = "", SelectedNotificationID = "", SelectedQuotationHeaderID = "", SelectedQuotationTotalPrice = "0.00";

//var array_notifications = null;
var array_notifications = [];
var array_related = [];
var array_timeline = [];
var array_damages = [];
var array_causes = [];
var array_master_damages = [];
var array_master_damagecode = [];
var array_master_causes = [];
var array_master_causecode = [];
var array_checklist = [];
var array_checklist_header = [];
var array_parts = []; 
var array_quotation = [];
var array_quotation_detail = [];
var array_travel_back = [];
var array_message = [];
var array_quotation_detail_print = [];
var array_checklist_template = [];

var array_notifications_upload = [];

var LatestDamageOrder = 0, LatestCauseOrder = 0;

var db = null;
var keyword = "";


var language_path = "lang/uilang-$.xml";
var SelectedLanguageID = "";
var DefaultLanguage = "";

var MessageForNotAbleToUpdate = "Damages not able to create", MessageForAlreadyExists = "Damages already exist", MessageForUpdateSuccess = "Damages added successfully";
var MessageForValidateDescription = "Please enter a Description for Damage";
var MessageConfirmFinish = "Job will be completed, Please check that you don't have any reserved material in the Spare Parts. Continue?";

var MessageForAlreadyExists_Cause = "Causes already exist"; 

var keys = new Array ();
keys[0] = "C4B96E1D-C02A-4ACC-B4DA-20AF9F858021";
keys[1] = "D83AA388-9F39-425F-BDF0-45FB74E627DD";
keys[2] = "003B4B9E-E02F-46A8-9432-295750C74D27";
keys[3] = "9CA246F3-F93F-4D63-910A-721E706DE80D";
keys[4] = "8CFFBDB6-AA8F-4407-A0CE-2862FA25B67D";
keys[5] = "2DBEB9DA-EB0F-413B-B115-D537205E6D6B";
keys[6] = "5CA0D927-D36F-4435-9D2D-31AB725433C3";
keys[7] = "77578BE5-8A0E-4D22-AA3D-517E280787B4";
keys[8] = "DDBF41EC-D8C2-43D8-9F9F-3A603EC83C4F";
keys[9] = "67776F98-6AB6-477C-8560-BB5FC867B3A1";
keys[10] = "7C42BE7A-E960-44D0-9D78-883541471897";
keys[11] = "4281ED77-470D-46D0-9DB2-761996B6E119";

function PrepareKey (key, source) {

  
  return source + key;

}
// Static Element ID
var TAB_NOTIFICATIONDETAIL_TABLE_RELATED = "Tab_NotificationDetail_Related_Table";
var TAB_TIMELINE_TABLE_HISTORY = "Tab_Timeline_History_Table";
var TAB_DETAIL_HISTORY_EQUIPMENT = "Tab_Detail_History_Equipment";
var TAB_DAMAGECAUSE_TABLE_DAMAGE = "Tab_DamageCause_Damage_Table";
var TAB_DAMAGECAUSE_TABLE_CAUSE = "Tab_DamageCause_Cause_Table";
var TAB_NOTIFICATION_LIST = "Tab_NotificationList";
var TAB_QUOTATION_TABLE = "Tab_Quotation_Table"; 
var TABLE_AVAILABLE_PARTS = "table_available_parts";
var TABLE_MESSAGE = "table_message";

var DRP_DAMAGEGROUP = "Dropdown_DamageGroup";
var DRP_EDIT_DAMAGEGROUP = "Dropdown_Edit_DamageGroup";
var DRP_DAMAGECODE = "Dropdown_DamageCode";
var DRP_EDIT_DAMAGECODE = "Dropdown_Edit_DamageCode";
var DRP_CHECKLISTTYPE = "Dropdown_CheckListType";

var DRP_CAUSEGROUP = "Dropdown_CauseGroup";
var DRP_EDIT_CAUSEGROUP = "Dropdown_Edit_CauseGroup";
var DRP_CAUSECODE = "Dropdown_CauseCode";
var DRP_EDIT_CAUSECODE = "Dropdown_Edit_CauseCode";

var DRP_RESERVEDPART = "Dropdown_ReservedPart";
var DRP_QUOTATIONPAYMENT = "Dropdown_QuotationPayment"; 
var DRP_VALIDITYPERIOD = "Dropdown_ValidityPeriod";

var TAB_CHECKLIST_TABLE = "TabChecklist_Table";
var TAB_PARTS_QUOTATION_TABLE = "Tab_Parts_Quotation_Table";
var TAB_PARTS_TABLE = "Tab_Parts_Table"; 


var ArrStatus = new Array ();
ArrStatus[0] = "E0001";
ArrStatus[1] = "E0003";
ArrStatus[2] = "E0004";
ArrStatus[3] = "E0005";
ArrStatus[4] = "E0006";
ArrStatus[5] = "E0007";
ArrStatus[6] = "E0008";
ArrStatus[7] = "E0009";
ArrStatus[8] = "E0010";
ArrStatus[9] = "E0011";
ArrStatus[10] = "E0012";
ArrStatus[11] = "E0013";
ArrStatus[12] = "E0014";
ArrStatus[13] = "E0015";
ArrStatus[14] = "E0016";
ArrStatus[15] = "E0017";
ArrStatus[16] = "E0018";
ArrStatus[17] = "E0019";
ArrStatus[18] = "E0020";
ArrStatus[19] = "E0021";

var ArrStatusDesc = new Array ();
ArrStatusDesc[0] = "Open";
ArrStatusDesc[1] = "Assigned";
ArrStatusDesc[2] = "Re-assignment";
ArrStatusDesc[3] = "In Process";
ArrStatusDesc[4] = "Quoted";
ArrStatusDesc[5] = "Parts Arranged";
ArrStatusDesc[6] = "Cancelled";
ArrStatusDesc[7] = "Finish";
ArrStatusDesc[8] = "Completed Job Email Sent";
ArrStatusDesc[9] = "Outstanding Job Email Sent";
ArrStatusDesc[10] = "Principal Escalation";
ArrStatusDesc[11] = "On Hold";
ArrStatusDesc[12] = "Monitoring";
ArrStatusDesc[13] = "Waiting for Parts";
ArrStatusDesc[14] = "Onsite Solution";
ArrStatusDesc[15] = "Remote Solution";
ArrStatusDesc[16] = "Wait for repair";
ArrStatusDesc[17] = "Quoted and returned";
ArrStatusDesc[18] = "Rpr done wait for rtrn to cust";
ArrStatusDesc[19] = "Delivered to customer";


var ArrPriority = new Array ();
ArrPriority[0] = "1";
ArrPriority[1] = "2";
ArrPriority[2] = "3";
ArrPriority[3] = "4";

var ArrPriorityDesc = new Array ();
ArrPriorityDesc[0] = "Emergency";
ArrPriorityDesc[1] = "High";
ArrPriorityDesc[2] = "Normal";
ArrPriorityDesc[3] = "Low";


var ArrPaymentTerm = new Array ();
ArrPaymentTerm[0] = "NT01";
ArrPaymentTerm[1] = "NT08";
ArrPaymentTerm[2] = "NT12";
ArrPaymentTerm[3] = "NT14";

var ArrPaymentTermDesc = new Array ();
ArrPaymentTermDesc[0] = "Cash On Delivery";
ArrPaymentTermDesc[1] = "30 days from Invoice date";
ArrPaymentTermDesc[2] = "60 days from Invoice date";
ArrPaymentTermDesc[3] = "120 days from Invoice date";



var htmltemplate_final = "";
var htmltemplate_TOS = "";
var htmltemplate_quotation = "";
var htmltemplate_Checklist = "";

function Load_ws_url(){
	$('#ws_connection_url').text(url_src);
}

function Load_release_version(){

	$('#release_version').text(android_version);	
}


function init () {
    
    current_notification = null;
    current_timeline = null;
    current_login = null;
    current_damages = null;
    current_part = [];


}

function reload_mainpage() {
	SelectedStatus = "";
	ClearList();
	array_notifications = [];
	LoadNotifications();
}

function queryerror(tx, err) {
	 
    alert("Error processing SQL: "+err);
}

function LoadDatabase(){
	
	//var endDate = new Date();
    //endDate.setDate(endDate.getDate() + 1); 
    //var twoDigitMonth = endDate.getMonth()+1;
    //if(twoDigitMonth.length==1)  twoDigitMonth="0" +twoDigitMonth;
	//var twoDigitDate = endDate.getDate()+"";
	//if(twoDigitDate.length==1) twoDigitDate="0" +twoDigitDate;
	//date_to = endDate.getFullYear() + "-" + twoDigitMonth + "-" + twoDigitDate;

	
	var d = new Date(); 
	var month = ("0" + (d.getMonth() + 1)).slice(-2);
	var day = ("0" + d.getDate()).slice(-2);
	var year = d.getFullYear();	

	//date_to = d.getFullYear() + "-" + ("0" + (d.getMonth() + 1)).slice(-2)  + "-" + ("0" + d.getDate()).slice(-2) ;
	date_to = d.getFullYear() + "-" + ("0" + (d.getMonth() + 1)).slice(-2)  + "-" + "31" ;
	date_now =  d.getFullYear() + "-" + ("0" + (d.getMonth() + 1)).slice(-2)  + "-" + ("0" + d.getDate()).slice(-2) ;
	
	
	db = new window.sqlitePlugin.openDatabase("swordfish_db", "");
	
	
}
 

function LoadDashboard() {

	db.transaction(function(tx){
		tx.executeSql("select count(*) as totalcompleted from op_notification where notification_status  =  'E0009' and notification_resp = '"+ current_login.user_id +"' ;", [], LoadCompletedJobLabel, errorCB);
	}, errorCB);

	
}
 
function LoadCompletedJobLabel(tx, results) {

	$('#lbl_total_completed_job').text(results.rows.item(0).totalcompleted); 

	db.transaction(function(tx){
		tx.executeSql("select count(*) as totalassigned from op_notification where notification_status  =  'E0003' and notification_resp = '"+ current_login.user_id +"'  and ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%')  ;", [], LoadAssignedJobLabel, errorCB);
	}, errorCB);

	
}

function LoadAssignedJobLabel(tx, results) {
	
	$('#lbl_total_assigned_job').text(results.rows.item(0).totalassigned); 

	db.transaction(function(tx){
		tx.executeSql("select count(*) as totalwaitingforpart from op_notification where notification_status  =  'E0015' and notification_resp = '"+ current_login.user_id +"' ;", [], LoadWaitingForPartJobLabel, errorCB);
	}, errorCB);

}

function LoadWaitingForPartJobLabel(tx, results) {
	
	$('#lbl_total_waiting_for_parts').text(results.rows.item(0).totalwaitingforpart); 
	
	db.transaction(function(tx){
		tx.executeSql("select count(*) as totalinprogress from op_notification where notification_status  =  'E0005' and notification_resp = '"+ current_login.user_id +"' ;", [], LoadInProgressJobLabel, errorCB);
	}, errorCB);

}

function LoadInProgressJobLabel(tx, results) {
	
	$('#lbl_total_in_progress').text(results.rows.item(0).totalinprogress); 
	
	// added on 20150113
	db.transaction(function(tx){
		tx.executeSql("select count(*) as total_unread_msg from op_message where msg_isread = '0' and engineer_id = '"+ current_login.user_id +"' ;", [], LoadMessageCountLabel, errorCB);
	}, errorCB);
	
}

function LoadMessageCountLabel(tx, results) {
		
	
	$('#lbl_total_msg').text(results.rows.item(0).total_unread_msg); 

}


function LoadNotifications() {


	db.transaction(LoadNotifications_queryDB, errorCB);

}

function LoadNotificationsByShort(val) {

	db.transaction(LoadNotificationsByShort_queryDB, errorCB);

}

function LoadLoginDetail(){

	
	
	db.transaction(function(tx){
		tx.executeSql("select * from master_users where user_id  =  '" + current_login + "';", [], LoadEmployeeDetail_querySuccess, errorCB);
	}, errorCB);
	
}

function LoadEmployeeDetail_querySuccess(tx, results){


	current_login = new obj_currentlogin(current_login);
	current_login.internal_id = results.rows.item(0).internal_id;
	current_login.user_id = results.rows.item(0).user_id;
	current_login.user_firstname = results.rows.item(0).user_firstname;
	current_login.user_lastname = results.rows.item(0).user_lastname;
	current_login.user_active = results.rows.item(0).user_active;
	
	
	current_login.user_dchannel = results.rows.item(0).user_dchannel;
	current_login.user_vno = results.rows.item(0).user_vno;
	current_login.user_plant = results.rows.item(0).user_plant;

	$('#Label_LoginUserName').text(current_login.user_firstname);

}

function LoadNotificationsByShort_queryDB(tx) {
	//$.isLoading( "hide" );
//alert(shortby);
ClearList();
	if(keyword.length > 0){
		
		ClearList();
		array_notifications = [];

	}

	if(SelectedStatus != "") {
		
		ClearList();
		array_notifications = [];

	}
	console.log("Querythom");
				console.log(shortby);
	
	if(shortby=="select")
	{
		
			if(SelectedStatus != "") {
				
				//tx.executeSql("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status where notification_status = '"+ SelectedStatus +"' and notification_resp = '" + current_login.user_id  + "' and notification_requiredstart <= '"+ date_to +"' and (notification_no LIKE '%" + keyword + "%' OR notification_subject LIKE '%" + keyword + "%')  order by notification_requiredstart, notification_subject, notification_no ;", [], LoadNotifications_querySuccess, errorCB);
				tx.executeSql("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status where notification_status = '"+ SelectedStatus +"' and notification_resp = '" + current_login.user_id  + "' and ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and (notification_no LIKE '%" + keyword + "%' OR notification_subject LIKE '%" + keyword + "%')  order by notification_requiredstart, notification_subject, notification_no ;", [], LoadNotifications_querySuccess, errorCB);
				console.log("Querythom");
				console.log(SelectedStatus);
			} else {
				
				//tx.executeSql("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status where notification_resp = '" + current_login.user_id  + "' and notification_requiredstart <= '"+ date_to +"' and (notification_no LIKE '%" + keyword + "%' OR notification_subject LIKE '%" + keyword + "%')  order by notification_requiredstart, notification_subject, notification_no ;", [], LoadNotifications_querySuccess, errorCB);
				tx.executeSql("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status where notification_resp = '" + current_login.user_id  + "' and ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and (notification_no LIKE '%" + keyword + "%' OR notification_subject LIKE '%" + keyword + "%')  order by notification_requiredstart, notification_subject, notification_no ;", [], LoadNotifications_querySuccess, errorCB);
				console.log("Querythom2");
				console.log(SelectedStatus);
			
			}
		
	}
	
	//short by hospital
	if(shortby=="Hospital")
	{
		
		console.log("Inside Hospitel");
		
			if(SelectedStatus != "") {
							
				tx.executeSql("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status where notification_status = '"+ SelectedStatus +"' and notification_resp = '" + current_login.user_id  + "' and ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and (notification_no LIKE '%" + keyword + "%' OR notification_subject LIKE '%" + keyword + "%')  order by notification_subject;", [], LoadNotifications_querySuccess, errorCB);
				console.log("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status where notification_status = '"+ SelectedStatus +"' and notification_resp = '" + current_login.user_id  + "' and ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and (notification_no LIKE '%" + keyword + "%' OR notification_subject LIKE '%" + keyword + "%')  order by notification_subject;");
				
			} else {
				
				
				tx.executeSql("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status where notification_resp = '" + current_login.user_id  + "' and ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and (notification_no LIKE '%" + keyword + "%' OR notification_subject LIKE '%" + keyword + "%')  order by notification_subject;", [], LoadNotifications_querySuccess, errorCB);
				console.log("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status where notification_status = '"+ SelectedStatus +"' and notification_resp = '" + current_login.user_id  + "' and ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and (notification_no LIKE '%" + keyword + "%' OR notification_subject LIKE '%" + keyword + "%')  order by notification_subject;");
				
			
			}
		
	}
	
	
	//short by date
	if(shortby=="Date")
	{
		
			if(SelectedStatus != "") {
							
				tx.executeSql("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status where notification_status = '"+ SelectedStatus +"' and notification_resp = '" + current_login.user_id  + "' and ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and (notification_no LIKE '%" + keyword + "%' OR notification_subject LIKE '%" + keyword + "%')  order by notification_requiredstart ASC;", [], LoadNotifications_querySuccess, errorCB);
				
			} else {
				
				
				tx.executeSql("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status where notification_resp = '" + current_login.user_id  + "' and ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and (notification_no LIKE '%" + keyword + "%' OR notification_subject LIKE '%" + keyword + "%')  order by notification_requiredstart ASC;", [], LoadNotifications_querySuccess, errorCB);
				
			
			}
		
	}
	
	
	//short by callno
	if(shortby=="callno")
	{
		
			if(SelectedStatus != "") {
							
				tx.executeSql("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status where notification_status = '"+ SelectedStatus +"' and notification_resp = '" + current_login.user_id  + "' and ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and (notification_no LIKE '%" + keyword + "%' OR notification_subject LIKE '%" + keyword + "%')  order by notification_no DESC;", [], LoadNotifications_querySuccess, errorCB);
				
			} else {
				
				
				tx.executeSql("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status where notification_resp = '" + current_login.user_id  + "' and ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and (notification_no LIKE '%" + keyword + "%' OR notification_subject LIKE '%" + keyword + "%')  order by notification_no DESC;", [], LoadNotifications_querySuccess, errorCB);
				
			
			}
		
	}
    

	
    
    
    
}



function LoadNotifications_queryDB(tx) {

	if(keyword.length > 0){
		
		ClearList();
		array_notifications = [];

	}

	if(SelectedStatus != "") {
		
		ClearList();
		array_notifications = [];

	}
	
	
	
	if (array_notifications.length == 0) {
		if(SelectedStatus != "") {
			ClearList();
			
			//tx.executeSql("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status where notification_status = '"+ SelectedStatus +"' and notification_resp = '" + current_login.user_id  + "' and notification_requiredstart <= '"+ date_to +"' and (notification_no LIKE '%" + keyword + "%' OR notification_subject LIKE '%" + keyword + "%')  order by notification_requiredstart, notification_subject, notification_no ;", [], LoadNotifications_querySuccess, errorCB);
			tx.executeSql("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status where notification_status = '"+ SelectedStatus +"' and notification_resp = '" + current_login.user_id  + "' and ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and (notification_no LIKE '%" + keyword + "%' OR notification_subject LIKE '%" + keyword + "%')  order by notification_requiredstart, notification_subject, notification_no ;", [], LoadNotifications_querySuccess, errorCB);
			//console.log("Querythom");
			console.log(SelectedStatus);
		} else {
			ClearList();
			//tx.executeSql("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status where notification_resp = '" + current_login.user_id  + "' and notification_requiredstart <= '"+ date_to +"' and (notification_no LIKE '%" + keyword + "%' OR notification_subject LIKE '%" + keyword + "%')  order by notification_requiredstart, notification_subject, notification_no ;", [], LoadNotifications_querySuccess, errorCB);
			tx.executeSql("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status where notification_resp = '" + current_login.user_id  + "' and ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and (notification_no LIKE '%" + keyword + "%' OR notification_subject LIKE '%" + keyword + "%')  order by notification_requiredstart, notification_subject, notification_no ;", [], LoadNotifications_querySuccess, errorCB);
			//console.log("Queryjeeva2");
			console.log("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status where notification_resp = '" + current_login.user_id  + "' and ( notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%') and (notification_no LIKE '%" + keyword + "%' OR notification_subject LIKE '%" + keyword + "%')  order by notification_requiredstart, notification_subject, notification_no ;");
		
		}
	}
	else{
		ClearList();
		BuildJobList(array_notifications);
	}
    

	
    
    
    
}


function LoadNotifications_querySuccess(tx, results) {

	
	/// here to set the array for notification detail
	/// set the first notification as current_notification
    //if (array_notifications.length == 0) {
	
	//$("#myloading").hide();
	document.getElementById("myloading").style.display="none";
	if ( results.rows.length > 0 ) {
    	///current_notification = array_notifications[0];
		
    	 var len = results.rows.length;

    	 for (var i=0; i< len; i++) {  
    		 	
    		 //current_notification = array_notifications[i];
    		 array_notifications[i] = results.rows.item(i);
    		 
    		 
    	 }
    }
   
    BuildJobList(array_notifications);
	
	
	

}

function LoadNotificationDetail (internal_id) {

	SelectedNotificationID = internal_id; 

	$.isLoading( "hide" );
	$('body').isLoading({ text: "Load Job Detail" });
	
	current_notification = new obj_notification();
	current_notification.internal_id = internal_id;

	
	db.transaction(LoadNotificationDetail_queryDB, errorCB);
	
	//console.log("Current");
	//console.log(JSON.stringify(current_notification));
	
	
	
}


function LoadNotificationDetail_queryDB(tx) {
	
	// Loop left job list and highlight selected notification
	var rowCount = $("#Tab_NotificationList" + " li").length;


	$("#Tab_NotificationList").find('li').each(function (i) {

		var jobid = $(this).attr('id'); 
		if(jobid == current_notification.internal_id) { 
			//add class 
			$(this).addClass("activejob");
			
			
		} else {
			//remove class
			$(this).removeClass("activejob");
		}

    });
    
	
    tx.executeSql("select * from op_notification inner join master_lookup on master_lookup.master_id = op_notification.notification_status  where internal_id = '" + current_notification.internal_id + "' ;", [], LoadNotificationDetail_querySuccess, errorCB);

}



function LoadNotificationDetail_querySuccess(tx, results) {
	
	/// Tab 1 : Detail

	current_notification = new obj_notification(current_notification.internal_id);
	current_notification.notification_id = results.rows.item(0).notification_no;
	current_notification.title = results.rows.item(0).notification_subject;
	current_notification.typeid = results.rows.item(0).notification_typeid;
	current_notification.activityid = results.rows.item(0).notification_activityid;
	current_notification.so = results.rows.item(0).notification_so;
	current_notification.soldtoid = results.rows.item(0).notification_soldtoid;
	current_notification.shiptoid = results.rows.item(0).notification_shiptoid;
	current_notification.status = results.rows.item(0).notification_status;
	current_notification.statusdesc = results.rows.item(0).master_desc;
	current_notification.priority = results.rows.item(0).notification_priority;
	current_notification.equipment = results.rows.item(0).notification_equipment;
	current_notification.objnr = results.rows.item(0).notification_objnr;
	current_notification.aufnr = results.rows.item(0).notification_aufnr;
	current_notification.signby = results.rows.item(0).notification_signby;
	current_notification.signbydisgn = results.rows.item(0).notification_signbydisgn;
	current_notification.signbydept = results.rows.item(0).notification_signbydept;
	current_notification.signbycontact = results.rows.item(0).notification_signbycontact;
	current_notification.signbyic =  results.rows.item(0).notification_signbyic;
	current_notification.requirestart = results.rows.item(0).notification_requiredstart;
	current_notification.requiredtime = results.rows.item(0).notification_requiredtime;
	current_notification.resp =  results.rows.item(0).notification_resp;
	current_notification.sapready = results.rows.item(0).notification_sapready;
	current_notification.operator = results.rows.item(0).notification_operator;

	var x = 0;
	while (x < ArrStatus.length)
	{
		
		if (ArrStatus[x] == current_notification.status ){ 
			current_notification.statusdesc = ArrStatusDesc[x];
			break;  // breaks out of loop completely
		}
		x = x + 1;
	  
	}


	var y = 0;
	
	while (y < ArrPriority.length)
	{	
		if (ArrPriority[y] == current_notification.priority ){ 
			current_notification.prioritydesc = ArrPriorityDesc[y];
			break;  // breaks out of loop completely
		}
		y = y + 1;
	  
	}

	
	/// load to label at Tab Detail 

	 $('#Label_Breadcrum_NotificationID').text(current_notification.notification_id);
	 
	 $('#Tab_Detail_Title').text( current_notification.notification_id + " - " + current_notification.statusdesc);
	 $('#Tab_Detail_NotificationName').text(current_notification.title);
	
	 $('#Tab_Detail_ServiceOrder_Value').text(current_notification.so);
	
	
	 $("#Tab_Detail_Priority_Value").text(current_notification.prioritydesc);
	 
	
	 
	
	
	db.transaction(LoadMasterLookup_queryDB, errorCB);
	
	
}

function LoadMasterLookup_queryDB(tx){
	
	tx.executeSql("select * from master_lookup where master_type = '" + "ACTIVITYTYPE" + "' and master_id = '" + current_notification.activityid + "' ;", [], LoadMasterLookup_querySuccess, errorCB);
	console.log("QueryActivity:"+ "select * from master_lookup where master_type = '" + "ACTIVITYTYPE" + "' and master_id = '" + current_notification.activityid + "' ;");
}

function LoadMasterLookup_querySuccess(tx, results){
	
	var len = results.rows.length; 
	
	if(len > 0){
		
		console.log("insidelen:"+results);
		current_notification.activity = new obj_masterlookup(current_notification.activityid);
		current_notification.activity.master_desc = results.rows.item(0).master_desc;
		current_notification.activity.master_type = results.rows.item(0).master_type;
		
		 $('#Tab_Detail_AccountType_Value').text(current_notification.activity.master_desc);
		 
		 
		 
	}
	console.log("outsidelen:"+results);
	
	
	db.transaction(LoadMasterEquipmnet_queryDB, errorCB);
	
	
}

function LoadMasterEquipmnet_queryDB(tx){
	
	tx.executeSql("select * from master_equipment where equipment_id = '" + current_notification.equipment + "' ;", [], LoadMasterEquipmnet_querySuccess, errorCB);
	
}

function LoadMasterEquipmnet_querySuccess(tx, results){
	
	var len = results.rows.length;

	if(len > 0){
		
		current_notification.equipment = new obj_equipment(current_notification.equipment);
		current_notification.equipment.equipmentid = results.rows.item(0).equipment_id;
		current_notification.equipment.equipmentdesc = results.rows.item(0).equipment_desc;
		current_notification.equipment.equipment_snr = results.rows.item(0).equipment_snr;
		current_notification.equipment.equipment_obj = results.rows.item(0).equipment_obj;
		current_notification.equipment.equipment_location = results.rows.item(0).equipment_location;
		current_notification.equipment.equipment_profile = results.rows.item(0).equipment_profile;
		
		 $('#Tab_Detail_EquipmentLocation_Value').text(current_notification.equipment.equipment_location);
		 $('#Tab_Detail_Equipment_Value').text(current_notification.equipment.equipmentdesc);
		 $("#Tab_Detail_EquipmentSNR_Value").text(current_notification.equipment.equipment_snr);
		 
		db.transaction(LoadCustomer_queryDB, errorCB);
		
	}
 
	 
	
}

function LoadCustomer_queryDB(tx){

	tx.executeSql("select * from master_customers where cust_customer = '" + current_notification.soldtoid + "' ;", [], LoadCustomer_querySuccess, errorCB);
	
}

function LoadCustomer_querySuccess(tx, results){
	 
	var len = results.rows.length;
	

	if(len > 0){
				
		current_notification.customer = new obj_customer(current_notification.soldtoid);
		current_notification.customer.cust_incoterms = results.rows.item(0).cust_incoterms;
		current_notification.customer.cust_incoterms2 = results.rows.item(0).cust_incoterms2;
		current_notification.customer.cust_customer = results.rows.item(0).cust_customer;
		current_notification.customer.cust_country = results.rows.item(0).cust_country;
		current_notification.customer.cust_name1 = results.rows.item(0).cust_name1;
		current_notification.customer.cust_name2 = results.rows.item(0).cust_name2;
		current_notification.customer.cust_city = results.rows.item(0).cust_city;
		current_notification.customer.cust_po = results.rows.item(0).cust_po;
		current_notification.customer.cust_region = results.rows.item(0).cust_region;
		current_notification.customer.cust_division = results.rows.item(0).cust_division;
		current_notification.customer.cust_street = results.rows.item(0).cust_street;
		current_notification.customer.cust_tel1 = results.rows.item(0).cust_tel1;
		current_notification.customer.cust_fax = results.rows.item(0).cust_fax;
		current_notification.customer.cust_salesorg = results.rows.item(0).cust_salesorg;
		current_notification.customer.cust_distrchannel = results.rows.item(0).cust_distrchannel;
		current_notification.customer.cust_currency = results.rows.item(0).cust_currency;
		current_notification.customer.cust_peymentterms = results.rows.item(0).cust_peymentterms;
		
		$("#Tab_Detail_SoldTo_Value").text(current_notification.customer.cust_name1);
		///modal customer detail
		$("#modallabel_customername1").text(current_notification.customer.cust_name1);
		$("#modallabel_customername2").text(current_notification.customer.cust_name2);
		$("#modallabel_customeraddress").text(current_notification.customer.cust_street + " " + current_notification.customer.cust_po + " " + current_notification.customer.cust_city);
		$("#modallabel_customertelephone").text(current_notification.customer.cust_tel1);
		$("#modallabel_customerfax").text(current_notification.customer.cust_fax);
		 	 
	}
	
	db.transaction(LoadRelated_queryDB, errorCB);
	
	
}

function LoadRelated_queryDB(tx){
	
	console.log("Related query : select * from op_notification where notification_operator = '" + current_notification.operator +
			"' and notification_activityid = '" + current_notification.activityid + "' and internal_id <> '" + current_notification.internal_id +
			"' AND notification_status NOT IN ('E0008', 'E0009','E0010')");
	
	tx.executeSql("select * from op_notification where notification_operator = '" + current_notification.operator +
			"' and ifnull(notification_operator,'') != '' and notification_activityid = '" + current_notification.activityid + "' and internal_id <> '" + current_notification.internal_id +
			"' AND notification_status NOT IN ('E0008', 'E0009','E0010') ;", [], LoadRelated_querySuccess, errorCB);

}

function LoadRelated_querySuccess(tx, results){
	
	if (array_related.length == 0) {
		
    	 var len = results.rows.length;
    	 
    	 for (var i=0; i< len; i++) {  
    		 	
    		 current_notification.array_related = array_related[i];
    		 array_related[i] = results.rows.item(i);
    		 
    	 }
    	 
    	 ClearRelatedNotifications();
    	 AddRelatedNotification(array_related);
    }

	/// load timeline detail 
	FormWizard.init();
	db.transaction(LoadTimelineHeaderDetail_queryDB, errorCB);
	
}

function UpdateLinkNotification () {
	
	if (confirm("Are you sure you want to update link notification ?")) {
		///loop table to get checked value 
		var table = $("#Tab_NotificationDetail_Related_Table tbody");

		$("#Tab_NotificationDetail_Related_Table tr").each(function (i) {

			var related_notification_id = $(this).attr('id'); 
			var $tds = $(this).find('td'); 
			var test_result = $tds.eq(1).find("input:checked").length;
			if (test_result =="1") {
				 
				///1. update timeline 
				var TempDate = new Date();
				var month = TempDate.getMonth() + 1;
				var day = TempDate.getDate();
				var year = TempDate.getFullYear();
				h = TempDate.getHours();
				m = TempDate.getMinutes();
				s = TempDate.getSeconds();
				
				var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
				var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s);       
				var msg_encrypt = hex_md5 (msg_source);		
				var a = msg_encrypt;
				var b = "-";
				var position1 = 8;
				var position2 = position1 + 4;
				var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');
				
				db.transaction(function(tx) {
						tx.executeSql("insert into op_timestamp " +
								"select '" + msg_encrypt_output + "', '" + related_notification_id + "', job_date, job_travel, job_waiting, job_travel_start, job_travel_end, " +
								"job_waiting_start, job_waiting_end, job_start, job_end, job_description, job_status, job_by, '0', op_shared " +
								"from op_timestamp where tstamp_notification  =  '" + current_notification.internal_id + "' AND job_status = 'JE' ;", [], "", errorCB);
						
						console.log("insert into op_timestamp " +
								"select '" + msg_encrypt_output + "', '" + related_notification_id + "', job_date, job_travel, job_waiting, job_travel_start, job_travel_end, " +
								"job_waiting_start, job_waiting_end, job_start, job_end, job_description, job_status, job_by, '0', op_shared " +
								"from op_timestamp where tstamp_notification  =  '" + current_notification.internal_id + "' AND job_status = 'JE' ;", [], "");
				});

				
				
				///2. update survey
				var surveyTempDate = new Date();
				var surveymonth = surveyTempDate.getMonth() + 1;
				var surveyday = surveyTempDate.getDate();
				var surveyyear = surveyTempDate.getFullYear();
				h = surveyTempDate.getHours();
				m = surveyTempDate.getMinutes();
				s = surveyTempDate.getSeconds();
				
				var surveyrindex = Math.floor((Math.random()*12)+1) - 1;                                   
				var surveymsg_source = PrepareKey(keys[surveyrindex], current_login.user_id + surveyday + surveymonth + surveyyear + h + m + s); 
				var surveymsg_encrypt = hex_md5 (surveymsg_source);		
				var a = surveymsg_encrypt;
				var b = "-";
				var position1 = 8;
				var position2 = position1 + 4;
				var surveymsg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');
				
				db.transaction(function(tx) {
					console.log("Survaylog");
					console.log("insert into op_survey " +
							"select '" + surveymsg_encrypt_output + "', '" + related_notification_id  + "', survey_comments, survey_date, survey_remarks " +
							"from op_survey where survey_notification  =  '" + current_notification.internal_id + "';");
					tx.executeSql("insert into op_survey " +
							"select '" + surveymsg_encrypt_output + "', '" + related_notification_id  + "', survey_comments, survey_date, survey_remarks " +
									"from op_survey where survey_notification  =  '" + current_notification.internal_id + "';", [], "", errorCB);
				});

				
				
				///3. update sign off
				var TempDate = new Date();
				var month = TempDate.getMonth() + 1;
				var day = TempDate.getDate();
				var year = TempDate.getFullYear();
				h = TempDate.getHours();
				m = TempDate.getMinutes();
				s = TempDate.getSeconds();
				
				var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
				var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s); 
				var msg_encrypt = hex_md5 (msg_source);		
				var a = msg_encrypt;
				var b = "-";
				var position1 = 8;
				var position2 = position1 + 4;
				var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');

				
				db.transaction(function(tx) {
					tx.executeSql("insert into op_signature " +
							"select '" + related_notification_id + "',notification_signature, signature_name, signature_contact, signature_dept, signature_designation, notification_signature_json " +
									"from op_signature where notification_id  =  '" + current_notification.internal_id + "';", [], "", errorCB);
				});
							
			}
			 
	    });
		
		alert("Notification link detail updated"); 
		
	}
	


}

function CreateRelatedSurvey (tx, results) {

	var len = results.rows.length;

	if (len > 0) {
		
		for (var i=0; i< array_related.length; i++) {  
			

			var TempDate = new Date();
			var month = TempDate.getMonth() + 1;
			var day = TempDate.getDate();
			var year = TempDate.getFullYear();
			h = TempDate.getHours();
			m = TempDate.getMinutes();
			s = TempDate.getSeconds();
			
			var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
			var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s); 
			var msg_encrypt = hex_md5 (msg_source);		
			var a = msg_encrypt;
			var b = "-";
			var position1 = 8;
			var position2 = position1 + 4;
			var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');

			db.transaction(function(tx) {
				tx.executeSql("delete from op_survey where survey_notification  =  '" + array_related[i].internal_id  + "';", [], "", errorCB);
			});
			

			db.transaction(function(tx) {
				tx.executeSql("insert into op_survey " +
						"select '" + msg_encrypt_output + "', '" + array_related[i].internal_id  + "', survey_comments, survey_date, survey_remarks " +
								"from op_survey where survey_notification  =  '" + current_notification.internal_id + "';", [], "", errorCB);
			});

		}
		
	} 
	
}


function CreateRelatedSignOff (tx, results) {
	 
	var len = results.rows.length;

	if (len > 0) {

		for (var i=0; i< array_related.length; i++) {   
			
			var TempDate = new Date();
			var month = TempDate.getMonth() + 1;
			var day = TempDate.getDate();
			var year = TempDate.getFullYear();
			h = TempDate.getHours();
			m = TempDate.getMinutes();
			s = TempDate.getSeconds();
			
			var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
			var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s); 
			var msg_encrypt = hex_md5 (msg_source);		
			var a = msg_encrypt;
			var b = "-";
			var position1 = 8;
			var position2 = position1 + 4;
			var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');

			db.transaction(function(tx) {
				tx.executeSql("delete from op_signature where notification_id  =  '" + array_related[i].internal_id + "';", [], "", errorCB);
			});

			db.transaction(function(tx) {
				tx.executeSql("insert into op_signature " +
						"select '" + array_related[i].internal_id + "',notification_signature, signature_name, signature_contact, signature_dept, signature_designation " +
								"from op_signature where notification_id  =  '" + current_notification.internal_id + "';", [], "", errorCB);
			});


		}
		
	} 

}

function LoadTimelineHeaderDetail_queryDB(tx){
	
	$.isLoading( "hide" );
	$('body').isLoading({ text: "Load Timeline" });

	tx.executeSql("select * from op_timestamp where tstamp_notification = '" + current_notification.internal_id + "' AND job_status = 'JS' ;", [], LoadTimelineHeaderDetail_querySuccess, errorCB);

}

function LoadTimelineHeaderDetail_querySuccess(tx, results){

	if(current_notification.status == "E0009") {
		$('#form_wizard_1').find('.button-submit').hide();
		$('#form_wizard_1').find('.button-next').hide();
	}

	var len = results.rows.length;
	 
	if (len > 0) {
		
		current_notification.timeline = new obj_notification(current_notification.internal_id);
		current_notification.timeline.internal_id = results.rows.item(0).internal_id;
		current_notification.timeline.tstamp_notification = results.rows.item(0).tstamp_notification;
		current_notification.timeline.job_date = results.rows.item(0).job_date;
		current_notification.timeline.job_travel = results.rows.item(0).job_travel;
		current_notification.timeline.job_waiting = results.rows.item(0).job_waiting;
		current_notification.timeline.job_travel_start = results.rows.item(0).job_travel_start;
		current_notification.timeline.job_travel_end = results.rows.item(0).job_travel_end;
		current_notification.timeline.job_waiting_start = results.rows.item(0).job_waiting_start;
		current_notification.timeline.job_waiting_end = results.rows.item(0).job_waiting_end;
		current_notification.timeline.job_start = results.rows.item(0).job_start;
		current_notification.timeline.job_end = results.rows.item(0).job_end;
		current_notification.timeline.job_description = results.rows.item(0).job_description;
		current_notification.timeline.job_status = results.rows.item(0).job_status;
		current_notification.timeline.job_by = results.rows.item(0).job_by;
		current_notification.timeline.op_updated_from_sap = results.rows.item(0).op_updated_from_sap;
		current_notification.timeline.op_shared = results.rows.item(0).op_shared;
		
		current_tstamp_id = current_notification.timeline.internal_id;
		
	    ///current = 1 : En route =  job_date, job_travel_start is filled in 
	    ///current = 2 : Stop Driving  = IF job_date, job_travel_start is filled in ... 
	    ///current = 3 : Start Waiting = IF job_travel_end, job_waiting_start is filled in ...
	    ///current = 4 : Job Start = IF job_waiting_end, job_start is filled in 
	    ///current = 5 : job Stop = IF job_end is filled in 
	    ///current = 6 : Back Journey
		
		 $("#Text_TimelineDesc").text(current_notification.timeline.job_description) ;
		 
		
		 var li_list = $('#form_wizard_1').bootstrapWizard().find('li');

		 if (current_notification.timeline.job_travel_start  !== undefined) {
			
			 jQuery(li_list[0]).addClass("done");
			 $('#form_wizard_1').bootstrapWizard('show',1);
			 $('.step-title', $('#form_wizard_1')).text('Step 2 of 6');
			 
		 } 
		 
		 if (current_notification.timeline.job_travel_end  !== undefined) {
			 
			 jQuery(li_list[1]).addClass("done");
			 $('#form_wizard_1').bootstrapWizard('show',2);
			 $('.step-title', $('#form_wizard_1')).text('Step 3 of 6');
			 
		 } 
		 
		 
		 if (current_notification.timeline.job_waiting_start  !== undefined) {
			 
			 jQuery(li_list[2]).addClass("done");
			 $('#form_wizard_1').bootstrapWizard('show',3);
			 $('.step-title', $('#form_wizard_1')).text('Step 4 of 6');
			
		 } 
		 
		 if (current_notification.timeline.job_start  !== undefined) {
			
			 jQuery(li_list[3]).addClass("done");
			 $('#form_wizard_1').bootstrapWizard('show',4);
			 $('.step-title', $('#form_wizard_1')).text('Step 5 of 6');

		 } 
 
		 
		 if (current_notification.timeline.job_end  !== undefined) {
			 
			 jQuery(li_list[4]).addClass("done");
			 $('#form_wizard_1').bootstrapWizard('show',5);
			 $('.step-title', $('#form_wizard_1')).text('Step 6 of 6');

		 }
		 
		

	} 
	
	db.transaction(LoadTimeline_queryDB, errorCB);
	
	
}

function LoadTimeline_queryDB(tx) {
	
    tx.executeSql("select a.*,b.user_firstname from op_timestamp as a , master_users as b where a.tstamp_notification = '" + current_notification.internal_id + "' AND a.job_status = 'JE' AND a.job_by=b.user_id  ORDER BY job_date ASC ;", [], LoadTimeline_querySuccess, errorCB);
   
}

function LoadTimeline_querySuccess(tx, results) {

	var allow_to_delete = false;
	var current_date = new Date();

	if (array_timeline.length == 0) {
		
    	 var len = results.rows.length;
    	 
    	 ClearHistory(); 
    	 
    	 
    	 for (var i=0; i< len; i++) {  
    		 
    		 
    		 current_notification.array_timeline = array_timeline[i];
    		 array_timeline[i] = results.rows.item(i);
    		 if(array_timeline[i].op_updated_from_sap == "0") {
    			 allow_to_delete = true;
    		 }
        	 AddHistory(array_timeline[i].internal_id , array_timeline[i].job_date , array_timeline[i].job_description, allow_to_delete,array_timeline[i].user_firstname)
    	 }

    }

	db.transaction(CheckTimelineStarted_queryDB, errorCB);

}

function ReloadTimeline() {
	
	TimelineStarted = false;
	$("#btn_job_finish").show();  
	
	$('body').isLoading({ text: "Refresh Timeline" });

	jQuery('li', $('#form_wizard_1')).removeClass("done");
	$('#form_wizard_1').bootstrapWizard('show',0);
	$('#form_wizard_1').find('.button-submit').hide();
	$('#form_wizard_1').find('.button-next').show();
	$("#Text_TimelineDesc").val('');
	$('.step-title', $('#form_wizard_1')).text('Step 1 of 6');
	 
	
	
	db.transaction(function(tx) {
		//tx.executeSql("select * from op_timestamp where tstamp_notification = '" + current_notification.internal_id + "' AND job_status = 'JE' ;", [], ReLoadTimeline_querySuccess, errorCB);
		tx.executeSql("select a.*,b.user_firstname from op_timestamp as a , master_users as b where a.tstamp_notification = '" + current_notification.internal_id + "' AND a.job_status = 'JE' AND a.job_by=b.user_id ;", [], ReLoadTimeline_querySuccess, errorCB);
	});

}

function ReLoadTimeline_querySuccess(tx, results) {
	var allow_to_delete = false;
	current_notification.array_timeline = [];
	array_timeline = [];

	var len = results.rows.length;
	
	if (results.rows.length > 0) {
		
    	 ClearHistory(); 

    	 for (var i=0; i< len; i++) {  
    		 current_notification.array_timeline = array_timeline[i];
    		 array_timeline[i] = results.rows.item(i);
    		 if(array_timeline[i].op_updated_from_sap == "0") {
    			 allow_to_delete = true;
    		 }
        	 AddHistory(array_timeline[i].internal_id , array_timeline[i].job_start , array_timeline[i].job_description, allow_to_delete,array_timeline[i].user_firstname)  		 
        	 //AddHistory(array_timeline[i].internal_id , array_timeline[i].job_date , array_timeline[i].job_description, true)
    	 } 
    }
	
	 ///here to reload summary
	ReLoadSummaryTab();
	LoadFinalTab(); 
	$.isLoading( "hide" );

}


function CheckTimelineStarted_queryDB(tx) {
	
	tx.executeSql("select op_timestamp.*, op_notification.notification_no from op_timestamp inner join op_notification on op_notification.internal_id = op_timestamp.tstamp_notification where job_status <> 'JE'  ;", [], CheckTimelineStarted_querySuccess, errorCB);

	
}

function CheckTimelineStarted_querySuccess (tx, results) {

	var len = results.rows.length;

	if (len > 0) {
		
		TimelineStarted = true;
		TimelineStarted_notification_no = results.rows.item(0).notification_no;
		TimelineStarted_notificationid = results.rows.item(0).tstamp_notification;
		
	}
	
	db.transaction(LoadDamages_queryDB, errorCB);
	
	
}


//********************************************************************************************************************
//*** BEGIN Damage / Cause Tab


function LoadDamages_queryDB(tx){
	
	$.isLoading( "hide" );
	$('body').isLoading({ text: "Load Damages/Causes" });
	
	
	tx.executeSql("select op_damages.*, master_damage.damage_desc as damage_code_desc, master_lookup.master_desc as damage_group_desc" +
			" from op_damages inner join master_damage on  master_damage.damage_group = op_damages.damage_group and master_damage.damage_code = op_damages.damage_code" +
			" inner join master_lookup on master_lookup.master_id = op_damages.damage_group " +
			" where master_lookup.master_type = 'DAMAGEGROUP' and damage_notification = '" + current_notification.internal_id + "' ;", [], LoadDamages_querySuccess, errorCB);

}

function LoadDamages_querySuccess(tx, results){
	
		
	if (array_damages.length == 0) {

		var len = results.rows.length;
		
		for (var i=0; i< len; i++) {  

			current_notification.array_damages = array_damages[i];
			array_damages[i] = results.rows.item(i);
		}
		
		ClearDamage();
		AddDamage(array_damages);
   }
	
	db.transaction(LoadCause_queryDB, errorCB);
	
	
}

function LoadCause_queryDB(tx){

	tx.executeSql("select op_causes.*, master_cause.cause_desc as cause_code_desc, master_lookup.master_desc as cause_group_desc" +
			" from op_causes inner join master_cause on  master_cause.cause_group = op_causes.cause_group and master_cause.cause_code = op_causes.cause_code " +
			" inner join master_lookup on master_lookup.master_id = op_causes.cause_group  " +
			" where master_lookup.master_type = 'CAUSEGROUP' and cause_notification = '" + current_notification.internal_id + "' order by cause_code_desc ;", [], LoadCause_querySuccess, errorCB);

}

function LoadCause_querySuccess(tx, results){
	
	if (array_causes.length == 0) {

		var len = results.rows.length;
   	
		for (var i=0; i< len; i++) {  

			current_notification.array_causes = array_causes[i];
			array_causes[i] = results.rows.item(i);
		}
		
		ClearCause();
		AddCause(array_causes);
   }
	
	db.transaction(LoadDamageGroup_queryDB, errorCB);
	
	
}

function LoadDamageGroup_queryDB(tx){
	
	if(current_notification.equipment.equipment_profile.length > 0 ){
		
		tx.executeSql("SELECT master_lookup.* FROM master_doc_relation, master_lookup " +
				" WHERE doc_type = 'DAMAGEGRP' AND master_type = 'DAMAGEGROUP' " +
				" AND master_id = doc_grp_id AND equipment_profile = '" + current_notification.equipment.equipment_profile + "' ;", [], LoadDamageGroup_querySuccess, errorCB);
		

	}
	else{
		
		tx.executeSql("SELECT master_lookup.* FROM master_doc_relation, master_lookup " +
				" WHERE doc_type = 'DAMAGEGRP' AND master_type = 'DAMAGEGROUP'  AND master_id = doc_grp_id  ;", [], LoadDamageGroup_querySuccess, errorCB);

	}
	

}

function LoadDamageGroup_querySuccess(tx, results){
	
	
	var len = results.rows.length;
   	
	for (var i=0; i< len; i++) {  

		current_notification.array_master_damages = array_master_damages[i];
		array_master_damages[i] = results.rows.item(i);
	}
	
	ClearMasterDamage();
	BuildMasterDamage(array_master_damages);

	/// here to build list of dropdown when add cause (pop up messagebox) 
	db.transaction(LoadCauseGroup_queryDB, errorCB);
	

	
}

function LoadDamageCode(DamageGroup){
	
	SelectedDamageGroup = DamageGroup; 
	
	db.transaction(GetDamageCode_queryDB, errorCB); 
	

	
}

function GetDamageCode_queryDB(tx){
	tx.executeSql("select * from master_damage where damage_group = '" + SelectedDamageGroup + "' ;", [], LoadDamageCode_querySuccess, errorCB);
}

function LoadDamageCode_querySuccess(tx, results){
	
	var len = results.rows.length;
	for (var i=0; i< len; i++) {  

		current_notification.array_master_damagecode = array_master_damagecode[i];
		array_master_damagecode[i] = results.rows.item(i);
	}
	
	ClearDamageCode();
	BuildDamageCode(array_master_damagecode);
	
}


function LoadEditDamageCode(DamageGroup){
	
	SelectedDamageGroup = DamageGroup; 
	
	//db.transaction(GetDamageCode_queryDB, errorCB); 
	db.transaction(function(tx) {
		tx.executeSql("select * from master_damage where damage_group = '" + SelectedDamageGroup + "' ;", [], LoadEditDamageCode_querySuccess, errorCB);
	});

	
}

function LoadEditDamageCode_querySuccess(tx, results){

	var len = results.rows.length;
	var str = "";

	if (len > 0) {
		
		for (var i=0; i< len; i++) {  

			//current_notification.array_master_damagecode = array_master_damagecode[i];
			array_master_damagecode[i] = results.rows.item(i);
		}

		$("#" + DRP_EDIT_DAMAGECODE + " option:gt(0)").empty();

		for (var x = 0; x < array_master_damagecode.length; x++) {
			if (array_master_damagecode[x].damage_code == CurEditDamageCode) {
				str = str + "<option value='" + array_master_damagecode[x].damage_code + "' selected>"  + array_master_damagecode[x].damage_desc;
			} else {
				str = str + "<option value='" + array_master_damagecode[x].damage_code + "' >"  + array_master_damagecode[x].damage_desc;
			}
			
			str = str + "</option>";

		    $("#" + DRP_EDIT_DAMAGECODE + " option:last").after(str);
		    
		    str = "";

		}

		
	}

	
}


function LoadCauseGroup_queryDB(tx){
	
	if(current_notification.equipment.equipment_profile.length > 0 ){
		
		tx.executeSql("SELECT master_lookup.* FROM master_doc_relation, master_lookup " +
				" WHERE doc_type = 'CAUSEGRP' AND master_type = 'CAUSEGROUP' " +
				" AND master_id = doc_grp_id AND equipment_profile = '" + current_notification.equipment.equipment_profile + "' ;", [], LoadCauseGroup_querySuccess, errorCB);

	}
	else{
		
		tx.executeSql("SELECT master_lookup.* FROM master_doc_relation, master_lookup " +
				" WHERE doc_type = 'CAUSEGRP' AND master_type = 'CAUSEGROUP'  AND master_id = doc_grp_id  ;", [], LoadCauseGroup_querySuccess, errorCB);

	}
	

}

function LoadCauseGroup_querySuccess(tx, results){
	
	
	var len = results.rows.length;
   	
	for (var i=0; i< len; i++) {  

		current_notification.array_master_causes = array_master_causes[i];
		array_master_causes[i] = results.rows.item(i);
	}
	
	ClearMasterCause();
	BuildMasterCause(array_master_causes);

	$.isLoading( "hide" );
	
	/// HERE TO LOAD CHECKLIST TAB 
	db.transaction(GetChecklistType, errorCB);

	
	
	
	
}

function LoadCauseCode(CauseGroup){

	
	SelectedCauseGroup = CauseGroup; 

	db.transaction(GetCauseCode_queryDB, errorCB); 
}

function GetCauseCode_queryDB(tx){
	
	tx.executeSql("select * from master_cause where cause_group = '" + SelectedCauseGroup + "' ;", [], LoadCauseCode_querySuccess, errorCB);
}

function LoadCauseCode_querySuccess(tx, results){
	
	var len = results.rows.length;
	for (var i=0; i< len; i++) {  

		current_notification.array_master_causecode = array_master_causecode[i];
		array_master_causecode[i] = results.rows.item(i);
	}
	
	ClearCauseCode();
	BuildCauseCode(array_master_causecode);
	
}

function LoadEditCauseCode(CauseGroup){
	
	SelectedCauseGroup = CauseGroup; 
	
	db.transaction(function(tx) {
		tx.executeSql("select * from master_cause where cause_group = '" + SelectedCauseGroup + "' ;", [], LoadEditCauseCode_querySuccess, errorCB);
	});

	
}

function LoadEditCauseCode_querySuccess(tx, results) {
	
	var len = results.rows.length;
	var str = "";

	if (len > 0) {
		
		for (var i=0; i< len; i++) {  
			array_master_causecode[i] = results.rows.item(i);
		}

		$("#" + DRP_EDIT_CAUSECODE + " option:gt(0)").remove();

		for (var x = 0; x < array_master_causecode.length; x++) {
			if(array_master_causecode[x].cause_code  == CurEditCauseCode){
				str = str + "<option value='" + array_master_causecode[x].cause_code + "' selected>"  + array_master_causecode[x].cause_desc;
			} else {
				str = str + "<option value='" + array_master_causecode[x].cause_code + "' >"  + array_master_causecode[x].cause_desc;
			}
			
			str = str + "</option>";

		    $("#" + DRP_EDIT_CAUSECODE + " option:last").after(str);
		    
		    str = "";

		}

		
	}

}


function GetChecklistType(tx){

	
	tx.executeSql("SELECT master_checklist_type.* FROM master_checklist_relation, master_checklist_type WHERE checklist_type = master_checklist_type.internal_id " +
			"AND dchannel = '" + current_login.user_dchannel + "' AND plant = '" + current_login.user_plant + "' ;", [], GetChecklistType_querySuccess, errorCB);
	console.log("Checklist query");
	console.log("SELECT master_checklist_type.* FROM master_checklist_relation, master_checklist_type WHERE checklist_type = master_checklist_type.internal_id " +
			"AND dchannel = '" + current_login.user_dchannel + "' AND plant = '" + current_login.user_plant + "' ;");
}

function GetChecklistType_querySuccess(tx, results){
	
	var len = results.rows.length;
	var str = "";
	
	
	
	ClearCheckListType();

	if(len == 0){
		//alert("Len=zero");

		$("#" + DRP_CHECKLISTTYPE).empty();
		
		//GetMasterCheckListType
		tx.executeSql("SELECT * FROM master_checklist_type ;", [], function(){
			len = results.rows.length;
			//alert(results.rows.length);
			for (var i=0; i< len; i++) {  

				//insert into dropdownlist 
				str = str + "<option value='" + results.rows.item(i).internal_id + "' >"  + results.rows.item(i).type_name;
				str = str + "</option>";

			    $("#" + DRP_CHECKLISTTYPE).append(str);
			    
			    str = "";
				
			}
			
		}, errorCB);

	}
	else{
		
		//alert("Len="+len);
		$("#" + DRP_CHECKLISTTYPE).empty();
		
		for (var i=0; i< len; i++) {  

			//insert into dropdownlist 
			str = str + "<option value='" + results.rows.item(i).internal_id + "' >"  + results.rows.item(i).type_name;
			str = str + "</option>";

		    ///$("#" + DRP_CHECKLISTTYPE + " option:last").after(str);
		    $("#" + DRP_CHECKLISTTYPE).append(str);
		    
		    str = "";
			
		}
		
	}
	
	$("#lbl_CheckList_HospitalName").text(current_notification.customer.cust_name1);
	$('#lbl_CheckList_ModelNo').text(current_notification.equipment.equipmentdesc);
	$("#lbl_CheckList_SN").text(current_notification.equipment.equipment_snr);
	
	
	///Load checklist data
	db.transaction(GetChecklistData, errorCB); 

}

function ReLoadChecklist(SelectedCheckListType){
	
	db.transaction(function(tx) {
		tx.executeSql("SELECT * FROM op_checklist_header WHERE notification_id = '" + current_notification.internal_id + "' AND checklist_type = '" + SelectedCheckListType + "' ;", [], ReLoadChecklist_querySuccess, errorCB);
	});
	
}

function ReLoadChecklist_querySuccess(tx, results){
	
	var a = document.getElementById(DRP_CHECKLISTTYPE);
	var strchecklisttype = a.options[a.selectedIndex].value;
	
	
	var len = results.rows.length;
	if (len == 0){

		tx.executeSql("SELECT * FROM master_checklist WHERE checklist_active = '1' and checklist_type = '" + strchecklisttype + "' order by checklist_seq;", [], ReLoadChecklistData, errorCB);

	}
	else{
		
		SelectedCheckListHeaderID = results.rows.item(0).internal_id;
		tx.executeSql("SELECT op_checklist_detail.*, master_checklist.checklist_question FROM op_checklist_detail inner join master_checklist  on master_checklist.internal_id = op_checklist_detail.checklist_id WHERE op_checklist_detail.checklist_header_id = '" + results.rows.item(0).internal_id + "' ;", [], ReLoadChecklistData, errorCB);

	}
	
	
}

function ReLoadChecklistData(tx, results) {
	
	var len = results.rows.length;

	array_checklist = [];
	
	if (array_checklist.length == 0) {

		for (var i=0; i< len; i++) {  

			current_notification.array_checklist = array_checklist[i];
			array_checklist[i] = results.rows.item(i);
			
		}
		
		ClearCheckList();
		BuildCheckList(array_checklist);
   }
	
	TableEditable.init();

}

function GetChecklistData(tx){
	
	
	var a = document.getElementById(DRP_CHECKLISTTYPE);
	var strchecklisttype = a.options[a.selectedIndex].value;
	
	tx.executeSql("SELECT * FROM op_checklist_header WHERE notification_id = '" + current_notification.internal_id + "' AND checklist_type = '" + strchecklisttype + "' ;", [], GetChecklistData_querySuccess, errorCB);

	
}

function GetChecklistData_querySuccess(tx, results){
	
	
	var len = results.rows.length;
	var a = document.getElementById(DRP_CHECKLISTTYPE);
	var strchecklisttype = a.options[a.selectedIndex].value;


	if (len == 0){

		tx.executeSql("SELECT * FROM master_checklist WHERE checklist_active = '1' and checklist_type = '" + strchecklisttype + "' order by checklist_seq;", [], LoadChecklistData, errorCB);

	}
	else{
		
		SelectedCheckListHeaderID = results.rows.item(0).internal_id;
		tx.executeSql("SELECT op_checklist_detail.*, master_checklist.checklist_question FROM op_checklist_detail inner join master_checklist  on master_checklist.internal_id = op_checklist_detail.checklist_id WHERE op_checklist_detail.checklist_header_id = '" + results.rows.item(0).internal_id + "' ;", [], LoadChecklistData, errorCB);

	}
	
	
}

function LoadChecklistData(tx, results){

	var len = results.rows.length;
	
	
	array_checklist = [];
	
	if (array_checklist.length == 0) {

		for (var i=0; i< len; i++) {  

			current_notification.array_checklist = array_checklist[i];
			array_checklist[i] = results.rows.item(i);
			
		}
		
		ClearCheckList();
		BuildCheckList(array_checklist);
   }
	
	TableEditable.init();

	///Load Parts Tab
	db.transaction(LoadNotificationParts, errorCB); 
	

}

function LoadReservedPart() {

	$("#txt_unit").val("EA");
	$("#txt_consumed").val("0");
	$("#txt_quantity").val("0");
	$("#txt_reserved").val("0");

	//temp force insert the vehicle detail 
	///db.transaction(function(tx) {
	///	tx.executeSql("insert into op_parts_vehicle values ( '000000000000246689', '9703299025',  'FUJITSU PART AUY20TFCMF THERMIS-ROOM', '1', null, null, 'EA', '0613', '2014-09-01' )  ;", [], "", errorCB);
	///});

	///load reserved part dropdown
	db.transaction(function(tx) {
		tx.executeSql("select * from op_parts_vehicle where part_vehicleid  =  '" +  current_login.user_vno + "';", [], LoadReservedPartList, errorCB);
	});

}

function LoadReservedPartList (tx, results) {
	
	
	
	var PartID_List = [];
	
	var str= "";
	var len = results.rows.length;

	if (len > 0) {
		
		$("#" + DRP_RESERVEDPART).find('option').remove();
		$("#" + DRP_RESERVEDPART).append("<option value=''>No parts number</option>");
		 
		for (var i=0; i< len; i++) {  

			//insert into dropdownlist 
			str = str + "<option value='" + results.rows.item(i).part_id + "'  >"  + results.rows.item(i).part_id;
			str = str + "</option>";
		    $("#" + DRP_RESERVEDPART + " option:last").after(str);
		    
		    str = "";
		    
		    PartID_List[i] = results.rows.item(i).part_id;

		}

		$("#txt_partno").remove();
		$("#PartNoList").append("<input onchange='PartNoKeyup()' id='txt_partno' type='text' class='span6 m-wrap' style='margin: 0 auto;' data-provide='typeahead' data-items='4' data-source='"+  JSON.stringify(PartID_List) +"' />");
		
		var content = $('#txt_partno').val();

		$('#txt_partno').keyup(function() { 
			
			 if ($('#txt_partno').val().length > 0) { 
 
				 db.transaction(function(tx) {
						tx.executeSql("select * from op_parts_vehicle where part_id  =  '" +  $('#txt_partno').val() + "';", [], function(tx, results){

							if (results.rows.length > 0) {
								
								 $("#txt_material_desc").val(results.rows.item(0).part_desc);
								 $("#txt_consumed").val(results.rows.item(0).part_consumed);
								 $("#txt_reserved").val(results.rows.item(0).part_reserved);
								 $("#txt_unit").val(results.rows.item(0).part_uom);

							}
							
						}, errorCB);
					
				 });
				 
				 $("#txt_material_desc").prop('disabled',true);
				 $("#txt_quantity").prop('disabled',true);
				// $("#txt_consumed").prop('disabled',true);
				 $("#txt_reserved").prop('disabled',false);
				 $("#txt_unit").prop('disabled',false);
				
			 } else {
				 $("#txt_material_desc").prop('disabled',false);
				 $("#txt_quantity").prop('disabled',true);
				 $("#txt_consumed").prop('disabled',false);
				 $("#txt_reserved").prop('disabled',true);
				 $("#txt_unit").prop('disabled',false);
			 }
		 });
		    
		            
		
	}

	
}

function PartNoKeyup(){
	
	 db.transaction(function(tx) {
			tx.executeSql("select * from op_parts_vehicle where part_id  =  '" +  $('#txt_partno').val() + "';", [], function(tx, results){
				
				if (results.rows.length > 0) {
					
					// $("#txt_quantity").val(results.rows.item(0).part_avail);
					 
					 
						var el = document.getElementById("Dropdown_ReservedPart");
						 for(var i=0; i<el.options.length; i++) {
							 if ( el.options[i].value == $('#txt_partno').val() ) {
								 el.selectedIndex = i;
								 FillToPartText($('#txt_partno').val());
						     break;
						   }
						 }
				}
				
			}, errorCB);
		
	 });
	 

	
}


function FillToPartText (PartNumber) { 

	$("#txt_partno").val(PartNumber);
	
	db.transaction(function(tx) {
		tx.executeSql("select * from op_parts_vehicle where part_id  =  '" +  PartNumber + "';", [], function(tx, results){
			if (results.rows.length > 0) {
				// $("#txt_quantity").val(results.rows.item(0).part_avail);
				 $("#txt_material_desc").val(results.rows.item(0).part_desc);
				 $("#txt_consumed").val(results.rows.item(0).part_consumed);
				 $("#txt_reserved").val(results.rows.item(0).part_reserved);
				 $("#txt_unit").val(results.rows.item(0).part_uom);
				 $("#txt_consumed").prop('disabled',false);
				 
			} else {
				 $("#txt_material_desc").prop('disabled',false);
				 $("#txt_material_desc").val("");
				 $("#txt_quantity").prop('disabled',true);
				 $("#txt_consumed").prop('disabled',false);
				 $("#txt_reserved").prop('disabled',true);
				 $("#txt_unit").prop('disabled',false);
				
				
			}
		}, errorCB);
		
	 });
	 
	
	
}

function GetParts_NewQuotation(){

	db.transaction(function(tx) {
		tx.executeSql("select * from op_parts where part_notification  =  '" + current_notification.internal_id + "';", [], LoadPart_NewQuotation, errorCB);
	});

}

function CreateParts () {


	var TempDate = new Date();
	var month = TempDate.getMonth() + 1;
	var day = TempDate.getDate();
	var year = TempDate.getFullYear();
	h = TempDate.getHours();
	m = TempDate.getMinutes();
	s = TempDate.getSeconds();
	
	var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
	var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s); 
	var msg_encrypt = hex_md5 (msg_source);		
	var a = msg_encrypt;
	var b = "-";
	var position1 = 8;
	var position2 = position1 + 4;
	var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');


	var partno = "0000";
	var Material = $("#txt_partno").val(); 
	var MaterialName =  $("#txt_material_desc").val(); 
	var Unit = $("#txt_unit").val();  
	
	var Consumed = "0";
	var VanQuantity = "0";
	var Reserved = "0";
	
	if( $("#txt_consumed").val().length > 0){
		var Consumed =  $("#txt_consumed").val(); 
	}
	if( $("#txt_quantity").val().length > 0){
		var VanQuantity = $("#txt_quantity").val(); 
	} 
	if( $("#txt_reserved").val().length > 0){
		var VanQuantity = $("#txt_reserved").val(); 
	} 

	var Description = $("#txt_material_desc").val(); 
	var ConsumedFromMobile = '1'; 
	var VehicleNo = current_login.user_vno; 
	var PartNotification = current_notification.internal_id; 
	var PartInUse = 0;
	var Preset = 0;

	var a = document.getElementById("Dropdown_ReservedPart");
	var strPartID = a.options[a.selectedIndex].value;
	
	if(strPartID.length > 1) {
		PartInUse = 1;
		
	}

	VanQuantity = Consumed;
	
	db.transaction(function(tx) {
		tx.executeSql("insert into op_parts values ('" + msg_encrypt_output+ "', '" + PartNotification + "', '"+ partno +"', '"+ VanQuantity +"' , '" + 
				Unit +"', '"+ Consumed +"', '"+ Material +"', '"+ MaterialName +"', '"+ PartInUse +"', '"+ Preset +"', '0', '"+ Consumed +"' , '1', '0', '1','0', " +
				" '"+ Reserved +"', '"+ VehicleNo +"' ) ;", [], ReloadPartTable, errorCB);
	});

}

function UpdateParts() {

	var Unit = $("#txt_edit_unit").val();
	var Consumed = $("#txt_edit_consumed").val();
	var Description = $("#txt_edit_material_desc").val();
	
	db.transaction(function(tx) {
		tx.executeSql("update op_parts set part_vehicleno = '"+  current_login.user_vno +"', op_consumed_from_mobile = '1', op_updated_from_mobile = '1', part_unit = '" + Unit + "', part_consumed = '" + Consumed + "', part_material_desc = '" + Description + "' where internal_id = '" + selected_partid + "' ;", [], ReloadPartTable, errorCB);
	});

	
}

function ReloadPartTable () {

	db.transaction(function(tx) {
		tx.executeSql("select * from op_parts where part_notification  =  '" + current_notification.internal_id + "';", [], ReLoadNotificationParts_querySuccess, errorCB);
	});
	
	
}

function ReLoadNotificationParts_querySuccess (tx, results) {
	
	var len = results.rows.length;

	if (len > 0) { 
				current_part = []; 
		
		for (var i=0; i< len; i++) {  
			
			current_part[i] = results.rows.item(i);
		}
		
		
		var str = "";


		$("#" + TAB_PARTS_TABLE + " tr:gt(0)").remove();
			
		$("#" + TAB_PARTS_TABLE + " > tbody:last").append("<tr id='0'><td></td><td></td><td></td><td></td><td></td><td></td></tr>");

		
		for (var x = 0; x < current_part.length; x++) {
		    
		    str = str + "<tr id='" + current_part[x].internal_id + "'>";

		    if(current_part[x].part_material.length > 0 && current_part[x].part_material != "NULL" ) {
		    	MaterialNo = current_part[x].part_material;
		    	str = str + "<td>" + current_part[x].part_material + "</td>";
		    } else {
		    	MaterialNo = "";
		    	str = str + "<td></td>";
		    }

		    str = str + "<td>" + current_part[x].part_material_desc + "</td>";
		    str = str + "<td>" + current_part[x].part_quantity + "</td>";
		    str = str + "<td>" + current_part[x].part_consumed + "</td>";
		    str = str + "<td>" + current_part[x].part_reserved + "</td>";
		    str = str + "<td>" + current_part[x].part_unit + "</td>";

		   /* if (current_part[x].op_updated_from_sap != "2") {
		    	if(current_part[x].op_updated_from_sap == "1") {
		    		str = str + "<td>&nbsp;</td>";
		    	} else {
		    		str = str +  "<td><a onclick=\"return DeletePart('" + current_part[x].internal_id + "', '" + MaterialNo + "');\" >Delete</a></td>";
		    	}
		    	//
		    	//str = str + "<td>&nbsp;</td>";
		    	str = str +  "<td><a onclick=\"return EditPart('" +  current_part[x].internal_id + "', '" + MaterialNo + "', '" + current_part[x].part_unit + "', '" +  current_part[x].part_consumed + "', '" + current_part[x].part_quantity + "', '" + 
			    current_part[x].part_reserved + "', '" + current_part[x].part_material_desc + "', '" + current_part[x].op_updated_from_sap + "');\" href='#modal_edit_part' data-toggle='modal' >Edit</a></td>";
			    
		    } else {
		    	str = str + "<td>&nbsp;</td>";
		    	str = str + "<td>&nbsp;</td>";
		    	
		    } Hided for V4 */
		    
		    str = str + "</tr>";	    
		    $("#" + TAB_PARTS_TABLE + " tr:last").after(str);
		        
		    str = "";


			
		}
		
	}
	
	 $("table#" + TAB_PARTS_TABLE + " tr#0").remove();
	
	document.getElementById('Button_Add_Part_Back').click();
	document.getElementById('Button_Edit_Part_Back').click();
	
	LoadFinalTab();
}

function LoadAvailableParts() {

	///load reserved part for modal table
	db.transaction(function(tx) {
		tx.executeSql("select * from op_parts_vehicle ;", [], LoadAvailablePartList, errorCB);
	});

}

function LoadAvailablePartList (tx, results) {

	var str= "";
	var len = results.rows.length;
	
	if (len > 0) {
		
		for (var x = 0; x < results.rows.length; x++) {
		    
		    str = str + "<tr id='" + results.rows.item(x).internal_id + "' >";
		    str = str + "<td>"+ results.rows.item(x).part_id +"</td>";
		    str = str + "<td>"+ results.rows.item(x).part_id_old +"</td>";
		    str = str + "<td>"+ results.rows.item(x).part_desc +"</td>";

		    
			if(results.rows.item(x).part_avail.length > 0){
		    	str = str + "<td>"+ results.rows.item(x).part_avail +"</td>";
		    } else {
		    	str = str + "<td>&nbsp;1</td>";
		    }

 
		    if(results.rows.item(x).part_reserved.length > 0){
		    	str = str + "<td>"+ results.rows.item(x).part_reserved +"</td>";
		    } else {
		    	str = str + "<td>&nbsp;2</td>";
		    }
		    
		    if(results.rows.item(x).part_consumed.length > 0){
		    	str = str + "<td>"+ results.rows.item(x).part_consumed +"</td>";
		    } else {
		    	str = str + "<td>&nbsp;3</td>";
		    }
		     
		    str = str + "<td>"+ results.rows.item(x).part_uom +"</td>";

		   
		    str = str + "</tr>";

		    $("#" + TABLE_AVAILABLE_PARTS + " tbody:last").append(str);
		    
		    str = "";
		    
		}
		
		$("#" + TABLE_AVAILABLE_PARTS + " tr#0").remove();
		
		TableEditable.init();
		
	    var oTable = $('#table_available_parts').dataTable({
	        "aLengthMenu": [
	            [5, 15, 20, -1],
	            [5, 15, 20, "All"] // change per page values here
	        ],
	        // set the initial value
	        "iDisplayLength": 5,
	        "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span6'i><'span6'p>>",
	       "sPaginationType": "bootstrap",
	        "oLanguage": {
	            "sLengthMenu": "_MENU_ records per page",
	            "oPaginate": {
	               "sPrevious": "Prev",
	               "sNext": "Next"
	           }
	      },
	        "aoColumnDefs": [{
	               'bSortable': false,
	               'aTargets': [0]
	           }
	       ]

	    });
	    
	    TableManaged.init();
	    
		
	} else {
		 
		str = str + "<tr id='1' >";
		str = str + "<td colspan='7'>No Available Parts</td>";
		str = str + "</tr>";
		$("#" + TABLE_AVAILABLE_PARTS + " tbody:last").append(str);
		$("#" + TABLE_AVAILABLE_PARTS + " tr#0").remove();
	}


}


function LoadPart_NewQuotation(tx, results){
	
	
	
	var len = results.rows.length;

	array_parts = [];
	
	if (array_parts.length == 0) {

		for (var i=0; i< len; i++) {  

			//scurrent_notification.array_parts = array_parts[i];
			array_parts[i] = results.rows.item(i);
			
		}
		
		ClearPartList_NewQuotation();
	
		BuildPartList_NewQuotation(array_parts);
   }

}

function LoadNotificationParts() {
	
	db.transaction(function(tx) {
		tx.executeSql("select * from op_parts where part_notification  =  '" + current_notification.internal_id + "';", [], LoadNotificationParts_querySuccess, errorCB);
	});
	
}

function LoadNotificationParts_querySuccess (tx, results) {

	var len = results.rows.length;

	if (len > 0) { 
		
		//current_part = new obj_part();
		current_part = []; 
		
		for (var i=0; i< len; i++) {  
			
			current_part[i] = results.rows.item(i);
		}
	}
	
	
	
	BuildPartsTable(current_part);
	
	/// Load Quotation Tab 
	db.transaction(LoadConfirmQuotation, errorCB);
	
}

function Datavalidate_CheckQuantity () {
	
	$('body').isLoading({ text: "Update quotation..." });
	
	var IsValid = true; 

	///data validate: check quantity if less than 0  

	var dataTable = $("#" + TAB_PARTS_QUOTATION_TABLE).dataTable();
	$(dataTable.fnGetNodes()).each(function(){

		if( $(this).find('td').eq(1).find('input').val().length > 0){
						
			var Quantity = $(this).find('td').eq(3).find('input').val();
			
			if (Quantity == 0) {
	        	
				alert("Quantity must be larger than 0 ..... " ); 
	        	
	        	IsValid = false;

	        	$.isLoading( "hide" );
	        	return false;	
	        	
			}
		} 
		
	    
	});

    if(IsValid == true) {
    	
    	CreateQuotation();
    }

}


function Datavalidate_CheckQuantity_Edit () {
	
	$('body').isLoading({ text: "Update quotation..." });
	
	var IsValid = true; 

	///data validate: check quantity if less than 0  

	var dataTable = $("#Tab_Parts_Quotation_Table_Edit").dataTable();
	$(dataTable.fnGetNodes()).each(function(){

		if( $(this).find('td').eq(1).find('input').val().length > 0){
						
			var Quantity = $(this).find('td').eq(3).find('input').val();
			
			if (Quantity == 0) {
	        	
				alert("Quantity must be larger than 0 ..... " ); 
	        	
	        	IsValid = false;

	        	$.isLoading( "hide" );
	        	return false;	
	        	
			}
		} 
		
	    
	});

    if(IsValid == true) {
    	
    	UpdateQuotation();
    }

}

function CreateQuotation () {

	
		/// OpQuotation
		var d = new Date(); 
		var month = ("0" + (d.getMonth() + 1)).slice(-2);
		var day = ("0" + d.getDate()).slice(-2);
		var year = d.getFullYear();	
		var h = d.getHours();
		var m = d.getMinutes();
		var s = d.getSeconds();
		  
		var today_date = ("0" + d.getDate()).slice(-2) + ("0" + (d.getMonth() + 1)).slice(-2) +  d.getFullYear() + h + m ;
		var quotation_date =  year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;
		
		SelectedQuotationInternalID = current_login.user_firstname + today_date;
		
		var quotationNotificationID = current_notification.internal_id; 
		var quotation_no =  current_notification.notification_id; 
		var quotation_remarks = $("#txt_quotation_remarks").val(); 
		var quotation_user_status = "";
		var quotation_engineer = current_login.user_id; 
		var quotation_status = "1" ;   //status = 1 is valid, status = 0 is deleted
		var quotation_currency = "MYR"; 
		var quotation_Incoterm1 = current_notification.customer.cust_incoterms;
		var quotation_Incoterm2 = current_notification.customer.cust_incoterms2;

		var a = document.getElementById(DRP_QUOTATIONPAYMENT);
		var quotationPayment = a.options[a.selectedIndex].value;

		var quotation_delivery_term = "Free Delivery to site"; 
		var quotation_attn = $("#txt_AttnTo").val();
		var quotation_fax_email = $("#txt_FaxEmail").val();
		var quotation_custname = current_notification.customer.cust_name1 + " " + current_notification.customer.cust_name2;
		var quotation_custaddress = current_notification.customer.cust_city +  current_notification.customer.cust_po + current_notification.customer.cust_division + current_notification.customer.cust_street; 

		var b = document.getElementById(DRP_VALIDITYPERIOD);
		var quotation_validity = b.options[b.selectedIndex].value;

		
		db.transaction(function(tx) {
			tx.executeSql("insert into op_quotation values" +
					" ('"+ SelectedQuotationInternalID +"', '"+ quotationNotificationID +"', '" + quotation_no + "', '"+ quotation_remarks +"', '"+ quotation_user_status +"', " +
					" null, null, '"+ quotation_engineer +"', '"+ quotation_status +"', '"+ quotation_currency +"', '"+ quotation_Incoterm1 +"', " +
							" '"+ quotation_Incoterm2 +"', '"+ quotationPayment +"', '"+ quotation_delivery_term +"', '"+ quotation_attn +"', '"+ quotation_fax_email +"', " +
									" '"+ quotation_date + "', '"+ quotation_custname +"', '"+ quotation_custaddress +"', '"+ quotation_validity +"', '0' ) ; ", [], CreateQuotationDetail, errorCB);
		});
	
}

function CreateQuotationDetail () {

	var IsDeleted = false; 

	db.transaction(function(tx) {
		tx.executeSql("delete from op_quotation_detail where detail_quotation  =  '" + SelectedQuotationInternalID + "';", [], IsDeleted = true, errorCB);
	});
	
	if(IsDeleted) {
		
	    var dataTable = $("#" + TAB_PARTS_QUOTATION_TABLE).dataTable();
	    $(dataTable.fnGetNodes()).each(function(){

			var TempDate = new Date();
			var month = TempDate.getMonth() + 1;
			var day = TempDate.getDate();
			var year = TempDate.getFullYear();
			h = TempDate.getHours();
			m = TempDate.getMinutes();
			s = TempDate.getSeconds();
			
	    	var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
	    	var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s); 
	    	var msg_encrypt = hex_md5 (msg_source);		
	    	var a = msg_encrypt;
	    	var b = "-";
	    	var position1 = 8;
	    	var position2 = position1 + 4;
	    	var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');

	    	var quotation_detailno = 100 + parseInt($(this).find('td').eq(0).text()); 
	    	var quotation_detail_desc = $(this).find('td').eq(1).find('input').val();
	    	var quotation_detail_qty = $(this).find('td').eq(3).find('input').val();
	    	var quotation_detail_rate = $(this).find('td').eq(4).find('input').val();
	    	var quotation_detail_discount = $(this).find('td').eq(5).find('input').val();
	    	var quotation_partno =  $(this).find('td').eq(2).find('input').val();
	    	var quotation_total_price = $(this).find('td').eq(6).text();

	    	// 
	    	
	    	if (quotation_detail_desc.length > 0) {
	    		db.transaction(function(tx) {
		    		tx.executeSql("insert into op_quotation_detail " +
		    				" values ( '"+ msg_encrypt_output +"', '"+ quotation_detailno +"', '"+ SelectedQuotationInternalID +"', '"+ quotation_detail_desc +"', " +
		    						" '"+ quotation_detail_qty +"', null, '"+ quotation_detail_rate +"', '"+ quotation_detail_discount +"', '"+ quotation_partno +"', '"+ quotation_total_price +"' ) ;", [], "", errorCB);
		    	});
	    	}


	    });
	     
	    ReLoadConfirmQuotation();
	    
	}
	
	
}

function ReLoadConfirmQuotation(){
	
	alert("Quotation update successfully "); 
	//tx.executeSql("SELECT * FROM op_quotation WHERE quotation_notification = '" + current_notification.internal_id + "' AND quotation_status = '1' ;", [], ReLoadConfirmQuotation_querySuccess, errorCB);
	
	db.transaction(function(tx) {
		tx.executeSql("SELECT * FROM op_quotation WHERE quotation_notification = '" + current_notification.internal_id + "' AND quotation_status = '1' ;", [], ReLoadConfirmQuotation_querySuccess, errorCB);
	});
	
}

function ReLoadConfirmQuotation_querySuccess(tx, results){
	
	array_quotation = [];
	
	if (array_quotation.length == 0) {

		var len = results.rows.length;
   	
		for (var i=0; i< len; i++) {  

			current_notification.array_quotation = array_quotation[i];
			array_quotation[i] = results.rows.item(i);
		}
		
		ClearConfirmQuotation();
		BuildConfirmQuotationTable(array_quotation);
   }
	
	$.isLoading( "hide" );
	
	
	$("#" + TAB_PARTS_QUOTATION_TABLE).dataTable().fnDestroy();
	
	document.getElementById('Button_Add_Quotation_Back').click();
	
}

function PrintTermOfSales() {

	  $.ajax({
	        url: 'swordfish_TOS_template.html',
	        type: 'get',
	        async: false,
	        success: function(html) {
	               // console.log(html); // here you'll store the html in a string if you want
	      	
	        	htmltemplate_TOS = html;
	      	 
	      	  window.requestFileSystem(LocalFileSystem.PERSISTENT, 0, gotFS_TOS, FileFail);

	        }

		  });
	  
	
}
		  


function gotFS_TOS(fileSystem) {
	
    fileSystem.root.getFile("swordfish_TOS_template.html", {create: true, exclusive: false}, gotFileEntry_TOS, FileFail);

}	


function gotFileEntry_TOS(fileEntry) {
	
    fileEntry.createWriter(gotFileWriter_TOS, FileFail);
}	

function gotFileWriter_TOS(writer) {

    writer.onwriteend = function(evt) {
       
        writer.truncate(0);
        writer.onwriteend = function(evt) {
            
            writer.seek(writer.length);
            writer.write(htmltemplate_TOS);
            writer.onwriteend = function(evt){

            }
            navigator.app.loadUrl("file://mnt/sdcard/swordfish_TOS_template.html", {openExternal : true});
        };
    };
    
    
    writer.write(htmltemplate_TOS);
   
}  


function QuotationPrint () {
	
	/// OpQuotation
	var d = new Date(); 
	var month = ("0" + (d.getMonth() + 1)).slice(-2);
	var day = ("0" + d.getDate()).slice(-2);
	var year = d.getFullYear();	
	var h = d.getHours();
	var m = d.getMinutes();
	
	var today_date = ("0" + d.getDate()).slice(-2) + ("0" + (d.getMonth() + 1)).slice(-2) +  d.getFullYear() + h + m ;
	var quotation_date =  year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;
	
	SelectedQuotationInternalID = current_login.user_firstname + today_date;
	
	var quotationNotificationID = current_notification.internal_id; 
	var quotation_no =  current_notification.notification_id; 
	var quotation_remarks = $("#txt_quotation_remarks").val(); 
	var quotation_user_status = "";
	var quotation_engineer = current_login.user_id; 
	var quotation_status = "1" ;   //status = 1 is valid, status = 0 is deleted
	var quotation_currency = "THB"; 
	var quotation_Incoterm1 = current_notification.customer.cust_incoterms;
	var quotation_Incoterm2 = current_notification.customer.cust_incoterms2;

	var a = document.getElementById(DRP_QUOTATIONPAYMENT);
	var quotationPayment = a.options[a.selectedIndex].value;

	var quotation_delivery_term = "Free Delivery to site"; 
	var quotation_attn = $("#txt_AttnTo").val();
	var quotation_fax_email = $("#txt_FaxEmail").val();
	var quotation_custname = current_notification.customer.cust_name1 + " " + current_notification.customer.cust_name2;
	var quotation_custaddress = current_notification.customer.cust_city +  current_notification.customer.cust_po + current_notification.customer.cust_region + current_notification.customer.cust_division + current_notification.customer.cust_street; 

	var b = document.getElementById(DRP_VALIDITYPERIOD);
	var quotation_validity = b.options[b.selectedIndex].value;


	db.transaction(function(tx) {
		tx.executeSql("insert into op_quotation values" +
				" ('"+ SelectedQuotationInternalID +"', '"+ quotationNotificationID +"', '" + quotation_no + "', '"+ quotation_remarks +"', '"+ quotation_user_status +"', " +
				" null, null, '"+ quotation_engineer +"', '"+ quotation_status +"', '"+ quotation_currency +"', '"+ quotation_Incoterm1 +"', " +
						" '"+ quotation_Incoterm2 +"', '"+ quotationPayment +"', '"+ quotation_delivery_term +"', '"+ quotation_attn +"', '"+ quotation_fax_email +"', " +
								" '"+ quotation_date + "', '"+ quotation_custname +"', '"+ quotation_custaddress +"', '"+ quotation_validity +"', '0' ) ; ", [], CreateQuotationDetail_Print, errorCB);
	});


}


function UpdateQuotation(){
	

	var quotation_remarks = $("#txt_quotation_remarks_edit").val(); 
	var quotation_attn = $("#txt_AttnTo_edit").val();
	var quotation_fax_email = $("#txt_FaxEmail_edit").val();
	
	var a = document.getElementById("Dropdown_QuotationPayment_edit");
	var quotationPayment = a.options[a.selectedIndex].value;
	
	var b = document.getElementById("Dropdown_ValidityPeriod_edit");
	var quotation_validity = b.options[b.selectedIndex].value;
	//update sql -- update op_quotation set xx where internal_id = ''
	db.transaction(function(tx) {
		tx.executeSql("update op_quotation set quotation_notice = '"+ quotation_remarks +"', quotation_attn = '"+ quotation_attn +
				"', quotation_paymentterm = '"+ quotationPayment +"', quotation_fax_email = '"+ quotation_fax_email +"', quotation_validity = '"+ quotation_validity + 
				"' where internal_id = '"+ SelectedQuotationHeaderID +"' ;", [], UpdateQuotationDetail, errorCB);
	});
	
	
}


function UpdateQuotationDetail(tx, results){


	var IsDeleted = false; 

	db.transaction(function(tx) {
		tx.executeSql("delete from op_quotation_detail where detail_quotation  =  '" + SelectedQuotationHeaderID + "';", [], IsDeleted = true, errorCB);
	});
	

	if(IsDeleted) {
		
	    var dataTable = $("#Tab_Parts_Quotation_Table_Edit").dataTable();
	    $(dataTable.fnGetNodes()).each(function(){

			var TempDate = new Date();
			var month = TempDate.getMonth() + 1;
			var day = TempDate.getDate();
			var year = TempDate.getFullYear();
			h = TempDate.getHours();
			m = TempDate.getMinutes();
			s = TempDate.getSeconds();
			
	    	var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
	    	var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s); 
	    	var msg_encrypt = hex_md5 (msg_source);		
	    	var a = msg_encrypt;
	    	var b = "-";
	    	var position1 = 8;
	    	var position2 = position1 + 4;
	    	var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');

	    	var quotation_detailno = 100 + parseInt($(this).find('td').eq(0).text()); 
	    	var quotation_detail_desc = $(this).find('td').eq(1).find('input').val();
	    	var quotation_detail_qty = $(this).find('td').eq(3).find('input').val();
	    	var quotation_detail_rate = $(this).find('td').eq(4).find('input').val();
	    	var quotation_detail_discount = $(this).find('td').eq(5).find('input').val();
	    	var quotation_partno =  $(this).find('td').eq(2).find('input').val();
	    	var quotation_total_price = $(this).find('td').eq(6).text();


	    	if (quotation_detail_desc.length > 0) {
	    		db.transaction(function(tx) {
		    		tx.executeSql("insert into op_quotation_detail " +
		    				" values ( '"+ msg_encrypt_output +"', '"+ quotation_detailno +"', '"+ SelectedQuotationHeaderID +"', '"+ quotation_detail_desc +"', " +
		    						" '"+ quotation_detail_qty +"', null, '"+ quotation_detail_rate +"', '"+ quotation_detail_discount +"', '"+ quotation_partno +"', '"+ quotation_total_price +"' ) ;", [], "", errorCB);
		    	});
	    	}

	    });
	   
	    ReLoadConfirmQuotation_Edit();
	    
	} else {
		$.isLoading( "hide" );
	}
	
	
}


function ReLoadConfirmQuotation_Edit(){
	
	alert("Quotation update successfully "); 

	db.transaction(function(tx) {
		tx.executeSql("SELECT * FROM op_quotation WHERE quotation_notification = '" + current_notification.internal_id + "' AND quotation_status = '1' ;", [], ReLoadConfirmQuotation_Edit_querySuccess, errorCB);
	});
	
}

function ReLoadConfirmQuotation_Edit_querySuccess(tx, results){
	
	array_quotation = [];
	
	if (array_quotation.length == 0) {

		var len = results.rows.length;
   	
		for (var i=0; i< len; i++) {  

			current_notification.array_quotation = array_quotation[i];
			array_quotation[i] = results.rows.item(i);
		}
		
		ClearConfirmQuotation();
		BuildConfirmQuotationTable(array_quotation);
   }
	
	$.isLoading( "hide" );
	
	
	$("#Tab_Parts_Quotation_Table_Edit").dataTable().fnDestroy();
	
	document.getElementById('Button_Edit_Quotation_Back').click();
	
}

function FinalPrint(){
	
	  $.ajax({
        url: 'swordfish_final_template.html',
        type: 'get',
        async: false,
        success: function(html) {
               // console.log(html); // here you'll store the html in a string if you want
      	
      	  htmltemplate_final = html;
      	 
      	  window.requestFileSystem(LocalFileSystem.PERSISTENT, 0, gotFS, FileFail);

        }

	  });
	  
}

function gotFS(fileSystem) {
	
    fileSystem.root.getFile("swordfish_final_template_print.html", {create: true, exclusive: false}, gotFileEntry, FileFail);

}	

function gotFileEntry(fileEntry) {
	
    fileEntry.createWriter(gotFileWriter, FileFail);
}	

function gotFileWriter(writer) {

	var str = "";
	
	
	/// here to replace the label in htmltemplate_final with the correct value 
	
	htmltemplate_final = htmltemplate_final.replace("#template_approvedby_img_src", (current_notification.signature.notification_signature == "")?"":"<img id ='tab_final_approvedby_img'  src = '"+ current_notification.signature.notification_signature +"' />" );
	htmltemplate_final = htmltemplate_final.replace("#template_signature_name", (current_notification.signature.signature_name == "")?"":current_notification.signature.signature_name );
	htmltemplate_final = htmltemplate_final.replace("#template_signature_desg", (current_notification.signature.signature_designation == "")?"":current_notification.signature.signature_designation );
	htmltemplate_final = htmltemplate_final.replace("#template_signature_dept", (current_notification.signature.signature_dept == "")?"":current_notification.signature.signature_dept );
	
	
	if(current_notification.signature.notification_id != ""){
	
		///alert("current_notification.signature.notification_id NOT blank ");
		htmltemplate_final = htmltemplate_final.replace("#template_approvedby_img_src", "<img id ='tab_final_approvedby_img'  src = '"+ current_notification.signature.notification_signature +"' />" );
	} else {
		///alert("current_notification.signature.notification_id BLANK ");
		htmltemplate_final = htmltemplate_final.replace("#template_approvedby_img_src", "");
	}
	
	//htmltemplate_final = htmltemplate_final.replace("#template_notification_no", current_notification.notification_id);
	htmltemplate_final = htmltemplate_final.replace("#template_notification_no", (current_notification.internal_id == "")?"":current_notification.internal_id);
	htmltemplate_final = htmltemplate_final.replace("#template_so", (current_notification.sp == "")?"":current_notification.so);
	htmltemplate_final = htmltemplate_final.replace("#template_customer", (current_notification.cust_name1 == "")?"":current_notification.customer.cust_name1 + current_notification.customer.cust_name2);
	htmltemplate_final = htmltemplate_final.replace("#template_address", (current_notification.customer.cust_street == "")?"":current_notification.customer.cust_street + current_notification.customer.cust_city + current_notification.customer.cust_po);
	htmltemplate_final = htmltemplate_final.replace("#template_telephone", (current_notification.customer.cust_tel1 == "")?"":current_notification.customer.cust_tel1);
	htmltemplate_final = htmltemplate_final.replace("#template_act_type", (current_notification.activity.master_desc == "")?"":current_notification.activity.master_desc);

	var FaultDesc = "";
	if (array_damages.length > 0) {
		for (var i=0; i< array_damages.length; i++) {  
			FaultDesc = array_damages[i].damage_code_desc;
		}	
	}
	htmltemplate_final = htmltemplate_final.replace("#template_fault_desc", (FaultDesc == "")?"":FaultDesc);
	
	var FaultCause = "";
	if (array_causes.length > 0) {
		for (var i=0; i< array_causes.length; i++) {  
		    FaultCause = array_causes[i].cause_code_desc;		    
		}
	}
	htmltemplate_final = htmltemplate_final.replace("#template_fault_cause", (FaultCause == "")?"":FaultCause);

	htmltemplate_final = htmltemplate_final.replace("#template_job_status", (current_notification.statusdesc == "")?"":current_notification.statusdesc);
	htmltemplate_final = htmltemplate_final.replace("#template_subject", (current_notification.title == "")?"":current_notification.title);
	htmltemplate_final = htmltemplate_final.replace("#template_model_no", (current_notification.equipment.equipmentid == "")?"":current_notification.equipment.equipmentid);
	htmltemplate_final = htmltemplate_final.replace("#template_serial_no", (current_notification.equipment.equipment_snr == "")?"":current_notification.equipment.equipment_snr);
	htmltemplate_final = htmltemplate_final.replace("#template_location", (current_notification.equipment.equipment_location == "")?"":current_notification.equipment.equipment_location);
	htmltemplate_final = htmltemplate_final.replace("#template_fax_email", (current_notification.customer.cust_fax == "")?"":current_notification.customer.cust_fax);
	

	if (array_timeline.length > 0) {
		str = "";
		for (var i=0; i< array_timeline.length; i++) {  

			str += "<tr id='" + array_timeline[i].internal_id  + "'>";
			str += "<td>" + (i+1) + "</td>";
			str += "<td>" + array_timeline[i].job_date + "</td>";
			str += "<td>" + array_timeline[i].job_description + "</td>";
			str += "</tr>";
		} 
		
	}
	htmltemplate_final = htmltemplate_final.replace("#template_tr_timeline", (str == "")?"":str);
	str = "";
	if (current_part.length > 0) {
		
		var k = 0;
		for (var j=0; j< current_part.length; j++) {  
			if(parseInt(current_part[j].part_consumed) > 0) {
				str += "<tr id='" + current_part[j].internal_id  + "'>";
				str += "<td>" + (k+1) + "</td>";
				str += "<td>" + current_part[j].part_material_desc + "</td>";
				str += "<td>" + current_part[j].part_consumed + "</td>";
				str += "<td>" + current_part[j].part_unit + "</td>";
				str += "</tr>";
				k= k+1;
			}
		} 	
	}
	htmltemplate_final = htmltemplate_final.replace("#template_tr_parts", (str == "")?"":str);

	if (array_timeline.length > 0) { 

		for (var k=0; k< array_timeline.length; k++) {
			
			if(array_timeline[k].job_start !== undefined) {
				htmltemplate_final = htmltemplate_final.replace("#template_travelling_time", array_timeline[0].job_travel);
				htmltemplate_final = htmltemplate_final.replace("#template_waiting_time", array_timeline[0].job_waiting);
				htmltemplate_final = htmltemplate_final.replace("#template_work_start", array_timeline[0].job_start);
				htmltemplate_final = htmltemplate_final.replace("#template_work_end", array_timeline[0].job_end);
				
			}

			//return false;
		}
	} else{
		htmltemplate_final = htmltemplate_final.replace("#template_travelling_time", "");
		htmltemplate_final = htmltemplate_final.replace("#template_waiting_time", "");
		htmltemplate_final = htmltemplate_final.replace("#template_work_start", "");
		htmltemplate_final = htmltemplate_final.replace("#template_work_end", "");
	}
	
	
	
	htmltemplate_final = htmltemplate_final.replace("#template_engineer",  (current_login.user_firstname == "")?"":current_login.user_firstname);
	htmltemplate_final = htmltemplate_final.replace("#template_survey_comment", (current_notification.survey.survey_comments == undefined)?"":current_notification.survey.survey_comments);
	htmltemplate_final = htmltemplate_final.replace("#template_survey_remarks", (current_notification.survey.survey_remarks == undefined)?"":current_notification.survey.survey_remarks);

	
    writer.onwriteend = function(evt) {
        //console.log("contents of file now 'some sample text'");
        writer.truncate(0);
        writer.onwriteend = function(evt) {
            //console.log("contents of file now 'some sample'");
            writer.seek(writer.length);
            writer.write(htmltemplate_final);
            writer.onwriteend = function(evt){
                //console.log("contents of file now 'some different text'");
            	
            }
            navigator.app.loadUrl("file://mnt/sdcard/swordfish_final_template_print.html", {openExternal : true});
        };
    };
    
    
    writer.write(htmltemplate_final);
    //navigator.app.loadUrl("file://mnt/sdcard/swordfish_final_template_print.html", {openExternal : true});
   
}    

function FileFail (error) {
	alert(error.code);
}

function FileSuccess(entry) {
    console.log("Removal succeeded");
}








function CreateQuotationDetail_Print () {
	
	var dataTable = $("#" + TAB_PARTS_QUOTATION_TABLE).dataTable();
    $(dataTable.fnGetNodes()).each(function(){
    	

		var TempDate = new Date();
		var month = TempDate.getMonth() + 1;
		var day = TempDate.getDate();
		var year = TempDate.getFullYear();
		h = TempDate.getHours();
		m = TempDate.getMinutes();
		s = TempDate.getSeconds();
		
    	var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
    	var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s); 
    	var msg_encrypt = hex_md5 (msg_source);		
    	var a = msg_encrypt;
    	var b = "-";
    	var position1 = 8;
    	var position2 = position1 + 4;
    	var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');

    	var quotation_detailno = 100 + parseInt($(this).find('td').eq(0).text()); 
    	var quotation_detail_desc = $(this).find('td').eq(1).text();
    	var quotation_detail_qty = $(this).find('td').eq(3).find('input').val();
    	var quotation_detail_rate = $(this).find('td').eq(4).find('input').val();
    	var quotation_detail_discount = $(this).find('td').eq(5).find('input').val();
    	var quotation_partno =  $(this).find('td').eq(2).text(); 
    	var quotation_total_price = $(this).find('td').eq(6).text();

    	db.transaction(function(tx) {
    		tx.executeSql("insert into op_quotation_detail " +
    				" values ( '"+ msg_encrypt_output +"', '"+ quotation_detailno +"', '"+ SelectedQuotationInternalID +"', '"+ quotation_detail_desc +"', " +
    						" '"+ quotation_detail_qty +"', null, '"+ quotation_detail_rate +"', '"+ quotation_detail_discount +"', '"+ quotation_partno +"', '"+ quotation_total_price +"' ) ;", [], CreateQuotationTemplate, errorCB);
    	});
    	
    });
     
	
}

function GetQuotation(){
	
	db.transaction(function(tx) {
		tx.executeSql("SELECT * FROM op_quotation WHERE internal_id = '" + SelectedQuotationHeaderID + "' ;", [], GetQuotation_querySuccess, errorCB);
		
	});

}

function GetQuotation_querySuccess(tx, results){
	
	if (results.rows.length > 0) {

		current_notification.quotation = new obj_quotation_header(SelectedQuotationHeaderID);
		current_notification.quotation.quotation_notification = results.rows.item(0).quotation_notification;
		current_notification.quotation.quotation_no = results.rows.item(0).quotation_no;
		current_notification.quotation.quotation_notice = results.rows.item(0).quotation_notice;
		current_notification.quotation.quotation_userstatus = results.rows.item(0).quotation_userstatus;
		current_notification.quotation.quotation_validfrom = results.rows.item(0).quotation_validfrom;
		current_notification.quotation.quotation_validto = results.rows.item(0).quotation_validto;
		current_notification.quotation.quotation_engineer = results.rows.item(0).quotation_engineer;
		current_notification.quotation.quotation_status = results.rows.item(0).quotation_status;
		current_notification.quotation.quotation_currency = results.rows.item(0).quotation_currency;
		current_notification.quotation.quotation_incoterm1 = results.rows.item(0).quotation_incoterm1;
		current_notification.quotation.quotation_incoterm2 = results.rows.item(0).quotation_incoterm2;
		current_notification.quotation.quotation_paymentterm = results.rows.item(0).quotation_paymentterm;
		current_notification.quotation.quotation_deliveryterm = results.rows.item(0).quotation_deliveryterm;
		current_notification.quotation.quotation_attn = results.rows.item(0).quotation_attn;
		current_notification.quotation.quotation_fax_email = results.rows.item(0).quotation_fax_email;
		current_notification.quotation.quotation_date = results.rows.item(0).quotation_date;
		current_notification.quotation.quotation_customer_name = results.rows.item(0).quotation_customer_name;
		current_notification.quotation.quotation_customer_address = results.rows.item(0).quotation_customer_address;
		current_notification.quotation.quotation_validity = results.rows.item(0).quotation_validity;
		
		db.transaction(function(tx) {
			tx.executeSql("SELECT * FROM op_quotation_detail WHERE detail_quotation = '" + SelectedQuotationHeaderID + "' ;", [], GetQuotationDetail_querySuccess, errorCB);
		});

	}


}

function GetQuotationDetail_querySuccess(tx, results){

	SelectedQuotationTotalPrice = "0.00";
	
	if ( results.rows.length > 0 ) {
    	 var len = results.rows.length;

    	 for (var i=0; i< len; i++) {  
    		 array_quotation_detail_print[i] = results.rows.item(i);
    		 SelectedQuotationTotalPrice =  parseFloat(SelectedQuotationTotalPrice) + parseFloat(array_quotation_detail_print[i].detail_total_price);
    			
    	 }
    }
	
	CreateQuotationTemplate();

}


function CreateQuotationTemplate () {
	
	  $.ajax({
	        url: 'swordfish_quotation_template.html',
	        type: 'get',
	        async: false,
	        success: function(html) {
	        	htmltemplate_quotation = html;
	        	window.requestFileSystem(LocalFileSystem.PERSISTENT, 0, gotFS_quotation, FileFail);
	        }

		  });

}

function gotFS_quotation(fileSystem) {
	
    fileSystem.root.getFile("swordfish_quotation_template.html", {create: true, exclusive: false}, gotFileEntry_quotation, FileFail);

}	

function gotFileEntry_quotation(fileEntry) {
	
    fileEntry.createWriter(gotFileWriter_quotation, FileFail);
}

function gotFileWriter_quotation(writer) {
	
	var PaymentTerm = ""; 
	var str = "";

	/// here to replace the label in htmltemplate_quotation with the correct value 
	var y = 0;
	
	while (y < ArrPaymentTerm.length)
	{	
		if (ArrPaymentTerm[y] == current_notification.quotation.quotation_paymentterm ){ 
			PaymentTerm = ArrPaymentTermDesc[y];
			break;  // breaks out of loop completely
		}
		y = y + 1;
	  
	}

	htmltemplate_quotation = htmltemplate_quotation.replace("#quotation_internal_id", (SelectedQuotationHeaderID== "")?"":SelectedQuotationHeaderID );
	htmltemplate_quotation = htmltemplate_quotation.replace("#quotation_date", (current_notification.quotation.quotation_date== "")?"":current_notification.quotation.quotation_date.substring(0,10) );
	htmltemplate_quotation = htmltemplate_quotation.replace("#quotation_no", (current_notification.quotation.quotation_no== "")?"":current_notification.quotation.quotation_no );
	htmltemplate_quotation = htmltemplate_quotation.replace("#customer_name", (current_notification.quotation.quotation_customer_name == "")?"":current_notification.quotation.quotation_customer_name );
	htmltemplate_quotation = htmltemplate_quotation.replace("#customer_address", (current_notification.quotation.quotation_customer_address == "")?"":current_notification.quotation.quotation_customer_address );
	htmltemplate_quotation = htmltemplate_quotation.replace("#quotation_attn", (current_notification.quotation.quotation_attn == "")?"":current_notification.quotation.quotation_attn );
	htmltemplate_quotation = htmltemplate_quotation.replace("#quotation_fax_email", (current_notification.quotation.quotation_fax_email == "")?"":current_notification.quotation.quotation_fax_email );
	htmltemplate_quotation = htmltemplate_quotation.replace("#quotation_sales_person", (current_login.user_firstname == "")?"":current_login.user_firstname );
	htmltemplate_quotation = htmltemplate_quotation.replace("#quotation_validity", (current_notification.quotation.quotation_validity == "")?"":current_notification.quotation.quotation_validity );
	htmltemplate_quotation = htmltemplate_quotation.replace("#quotation_payment", (current_notification.quotation.quotation_paymentterm == "")?"":PaymentTerm );
	htmltemplate_quotation = htmltemplate_quotation.replace("#quotation_notice", (current_notification.quotation.quotation_notice == "")?"":current_notification.quotation.quotation_notice );


	if (array_quotation_detail_print.length > 0) {
		str = "";
		for (var i=0; i< array_quotation_detail_print.length; i++) {  

			str += "<tr id='" + array_quotation_detail_print[i].internal_id  + "'>";
			str += "<td width='5%'><font face='arial' size='4'>"+ (i+1) +"</font></td>"; 
			str += "<td width='35%'><font face='arial' size='4'>"+ array_quotation_detail_print[i].detail_description +"</font></td>";
			str += "<td width='20%'><font face='arial' size='4'>"+ array_quotation_detail_print[i].detail_partno +"</font></td>";
			str += "<td width='10%'><font face='arial' size='4'>"+ array_quotation_detail_print[i].detail_quantity +"</font></td>";
			str += "<td width='10%' align='right'><font face='arial' size='4'>"+ array_quotation_detail_print[i].detail_rate +"</font></td>";
			str += "<td width='10%' align='center'><font face='arial' size='4'>"+ array_quotation_detail_print[i].detail_discount +"</font></td>";
			str += "<td width='10%' align='right'><font face='arial' size='4'>"+ array_quotation_detail_print[i].detail_total_price +"</font></td>";

			str += "</tr>";
		} 
		
	}
	htmltemplate_quotation = htmltemplate_quotation.replace("#template_tr_parts", (str == "")?"":str);
	var totalPrice = (SelectedQuotationTotalPrice == "")?"0.00":SelectedQuotationTotalPrice.toFixed(2);
	var gtotal = SelectedQuotationTotalPrice + ((6/100)*SelectedQuotationTotalPrice);
	console.log("totalPrice");
	console.log(totalPrice);
	console.log("gtotal");
	console.log(gtotal);
	
	htmltemplate_quotation = htmltemplate_quotation.replace("#TotalPrice",  totalPrice);
	htmltemplate_quotation = htmltemplate_quotation.replace("#GrandTotalPrice", gtotal.toFixed(2));
	htmltemplate_quotation = htmltemplate_quotation.replace("#engineer_name", (current_login.user_firstname == "")?"":current_login.user_firstname );

    writer.onwriteend = function(evt) {
        //console.log("contents of file now 'some sample text'");
        writer.truncate(0);
        writer.onwriteend = function(evt) {
            //console.log("contents of file now 'some sample'");
            writer.seek(writer.length);
            writer.write(htmltemplate_quotation);
            writer.onwriteend = function(evt){
                //console.log("contents of file now 'some different text'");
            	
            }
            navigator.app.loadUrl("file://mnt/sdcard/swordfish_quotation_template.html", {openExternal : true});
        };
    };
    
    
    writer.write(htmltemplate_quotation);
   
}  




















function LoadParts(){
	LoadDatabase();
	db.transaction(LoadParts_queryDB, errorCB);
}

function LoadParts_queryDB(tx){
	
	tx.executeSql("select * from op_parts where part_notification = '" + current_notification.internal_id + "' ;", [], LoadParts_querySuccess, errorCB);

}

function LoadParts_querySuccess(tx, results){
	
	current_notification.array_parts = null;
	
	current_part = new obj_part();
	current_part.internal_id = results.rows.item.internal_id;
	current_part.part_notification = results.rows.item.part_notification;
	current_part.part_no = results.rows.item.part_no;
	current_part.part_quantity = results.rows.item.part_quantity;
	current_part.part_unit = results.rows.item.part_unit;
	current_part.part_consumption = results.rows.item.part_consumption;
	current_part.part_material = results.rows.item.part_material;
	current_part.part_material_desc = results.rows.item.part_material_desc;
	current_part.part_inuse = results.rows.item.part_inuse;
	current_part.part_preset = results.rows.item.part_preset;
	current_part.op_sys = results.rows.item.op_sys;
	current_part.part_consumed = results.rows.item.part_consumed;
	current_part.op_consumed_from_mobile = results.rows.item.op_consumed_from_mobile;
	current_part.op_consumed_from_sap = results.rows.item.op_consumed_from_sap;
	current_part.op_updated_from_mobile = results.rows.item.op_updated_from_mobile;
	current_part.op_consumed_from_sap = results.rows.item.op_consumed_from_sap;
	current_part.part_reserved = results.rows.item.part_reserved;
	current_part.part_vehicleno = results.rows.item.part_vehicleno;
	
	if (current_notification.array_parts.length > 0) {
    	 var len = results.rows.length;
    	 for (var i=0; i< len; i++) {  
    		 	
    		 current_part = current_notification.array_parts[i];
    		 obj_notification.array_parts[i] = results.rows.item(i);
    	 }
    	 
 
    }
	
	
}

function errorCB(tx, err) {
	
    alert("Error processing SQL: "+err);
}



// ScreenTranslate
// Translate label on the screen
// by Victor Tai 
function ScreenTranslate(lang) {
	
  var file_path = language_path.replace ("$", lang);

  
  $.ajax({
      type : "GET",
      url: file_path,
      dataType: "xml",	      
      success: function(xml) {
    	  
    	  
	   $(xml).find("FormMain").each(function(){
		   $("#TabNotificationDetail").text($(xml).find("TabNotificationDetail").text());
		   $("#TabTimelime").text($(xml).find("TabTimelime").text());
		   $("#TabDamageCause").text($(xml).find("TabDamageCause").text());
		   $("#TabParts").text($(xml).find("TabParts").text());
		   $("#TabChecklist").text($(xml).find("TabChecklist").text());
		   $("#TabQuotation").text($(xml).find("TabQuotation").text());
		   $("#TabSummary").text($(xml).find("TabSummary").text());
		   $("#TabFinal").text($(xml).find("TabFinal").text());
		   $("#TabSignOff").text($(xml).find("TabSignOff").text());
		   
		   $("#Tab_Detail_Tab_Detail_AccountType_Label").text($(xml).find("ActType").text());
		   $("#Tab_Detail_SoldTo_Label").text($(xml).find("SoldTo").text());
		   $("#Tab_Detail_ServiceOrder_Label").text($(xml).find("ServiceOrder").text());
		   $("#Tab_Detail_Priority_Label").text($(xml).find("Priority").text());
		   $("#Tab_Detail_Equipment_Label").text($(xml).find("Equipment").text());
		   $("#Tab_Detail_EquipmentLocation_Label").text($(xml).find("EquipmentLocation").text());
		   $("#Tab_Detail_EquipmentSNR_Label").text($(xml).find("EquipmentSnr").text());
		   $("#Tab_Detail_Label_RelatedNotification").text($(xml).find("RelatedNotification").text());
		   $("#Tab_Detail_Table_Column_NotificationID").text($(xml).find("NotificationID").text());
		   $("#Tab_Detail_Table_Column_Subject").text($(xml).find("SubjectColumnOnDatagrid").text());
		   
		   $("#Tab_Timeline_Title_Label").text($(xml).find("TabTimelime").text());
		   $("#Tab_Timeline_Hitory_Title_Label").text($(xml).find("TimelineHistory").text());
		   $("#Tab_Timeline_Hitory_Table_Column_Date").text($(xml).find("DateOnDataGrid").text());
		   $("#Tab_Timeline_Hitory_Table_Column_Description").text($(xml).find("DescriptOnDataGrid").text());

		   
		   
	   });
	   
	   
	   $(xml).find("FormAddEditDamage").each(function(){
		   
		   $("#AddDamage").text($(this).find("AddDamage").text());
		   $("#DamageGroup").text($(this).find("Group").text());
		   $("#DamageCode").text($(this).find("Code").text());
		   $("#DamageDescription").text($(this).find('Description').text());
		   
	   });

	   $(xml).find("FormAddEditCause").each(function(){
		   
		   $("#AddCause").text($(this).find("AddCause").text());
		   $("#CauseGroup").text($(this).find("Group").text());
		   $("#CauseCode").text($(this).find("Code").text());
		   $("#DamageDescription").text($(this).find('Description').text());
		   
	   });
	   
	   
      }
  });
  
     
  
}


//--- Listing 
// BuiltList
// Building list based on Array
function BuiltList(id, array_obj) {



}

// ClearList
function ClearList() {

	$("#" + TAB_NOTIFICATION_LIST + " li").each(function(){
		//alert($(this).attr('id'));
		//alert($(this).attr('id').length);
		if($(this).attr('id').length >= 2 ) {
			$(this).remove();
		}
	});
	

}



// ********************************************************************************************************************

//*** BEGIN Notification Detail

// ClearRelatedNotifications
// by Victor Tai     
function ClearRelatedNotifications () {
$("#" + TAB_NOTIFICATIONDETAIL_TABLE_RELATED + " tr:gt(0)").remove();
}    


// AddRelatedNotification
// Input Param: Array of Notification Object
// by Victor Tai 
function AddRelatedNotification (array_related) {

	var str = "";
	
	for (var x = 0; x < array_related.length; x++) {
		
	    str = str + "<tr id='" + array_related[x].internal_id + "'>";
	    str = str + "<td>" + (x + 1) + "</td>";
	    str = str + "<td><input type='checkbox' class='checkboxes' value='1' /></td>";
	    str = str + "<td>" + array_related[x].notification_no + "</td>";
	    
	    str = str + "<td>" + array_related[x].notification_subject + "</td>";
	    
	    str = str + "</tr>";
	    
	    $("#" + TAB_NOTIFICATIONDETAIL_TABLE_RELATED + " tr:last").after(str);
	    str = "";
	}
	
	
}

//*** END Notification Detail 

// ********************************************************************************************************************

//*** BEGN Timeline

// ClearHistory
// by Victor Tai
function ClearHistory () {

$("#" + TAB_TIMELINE_TABLE_HISTORY + " tr:gt(0)").remove();


}
//get user name by user id 

function GetUsernameById(id)
{
	console.log("GetUsernameById called");
	var resultuser="thom";
	db.transaction(function(tx) {
		tx.executeSql("select * from master_users where user_id='"+id+"'", [], 
			    function(tx, results){
			console.log(results);
			resultuser = results.rows.item(0).user_firstname;
			
			console.log("Usernamethom");
		}, function(){
		        console.error("GetUsernameById ERROR");
		});
	});
	return resultuser;
}

// AddHistory
// by Victor Tai
function AddHistory(id, date_str, desc, able_delete,job_by) {
	
	var str = "<tr id='" + id + "'>";
	str += "<td>" + date_str + "</td>";
	str += "<td>" + desc + "</td>";
	str += "<td>" + job_by + "</td>";
	str += "<td>" + ((able_delete)?"<a href=\"#\" onclick=\"DeleteHistory('" + id + "', '" + date_str + "')\">Delete</a>":"") + "</td>";
	str = str +  "<td>" + ((able_delete)?"<a onclick=\"return LoadHistoryDesc('" +  id + "');\" href='#modal_edit_timeline_desc' data-toggle='modal' >Edit</a>":"") + "</td>";
    str += "</tr>";

    
    
$("#" + TAB_TIMELINE_TABLE_HISTORY + " tr:last").after(str);

}

function DeleteHistory (id, desc) {


	if (confirm("Are you sure you want to delete this timeline: " + desc + "?")) {
    
		// delete from database here
		
		db.transaction(function(tx) {
			tx.executeSql("delete from op_timestamp where internal_id  =  '" + id + "';", [], $("#" + id).remove(), errorCB);
		});
 
		 

	}

}

function LoadHistoryDesc(Param_SelectedTimelineID) {
	 
	SelectedTimelineID = Param_SelectedTimelineID; 
	db.transaction(function(tx) {
		tx.executeSql("select * from op_timestamp where internal_id  =  '" + SelectedTimelineID + "';", [], LoadHistoryDesc_querysuccess, errorCB);
	});

}

function LoadHistoryDesc_querysuccess(tx, results) {
	
	if(results.rows.length > 0) {
		
		$('#modal_job_date').text(results.rows.item(0).job_date);
		$('#modal_travel_start').text(results.rows.item(0).job_travel_start);
		$('#modal_travel_end').text(results.rows.item(0).job_travel_end);
		$('#modal_waiting_start').text(results.rows.item(0).job_waiting_start);
		$('#modal_waiting_end').text(results.rows.item(0).job_waiting_end);
		$('#modal_job_start').text(results.rows.item(0).job_start);
		$('#modal_job_end').text(results.rows.item(0).job_end);
		
		$('#Edit_TimelineDescription_text').text(results.rows.item(0).job_description) ;
		
	}
	
}

function update_timeline_desc(){
	
	
	//db.transaction(function(tx) {
	//	tx.executeSql("update op_timestamp set job_description = '"+ $('#Edit_TimelineDescription_text').val() +"' where internal_id = '"+ SelectedTimelineID +"' ;", [], "", errorCB);
	//});
	
	db.transaction(function(tx) {
		tx.executeSql("update op_timestamp set job_description = '"+ $('#Edit_TimelineDescription_text').val().replace("'", "''") +"' where internal_id = '"+ SelectedTimelineID +"' ;", [], "", errorCB);
	});
	
	ReloadTimeline();
	document.getElementById('Button_Edit_Timeline_Back').click();
	
}


function UpdateTimeLine(TimelineStepCount){

	var JobDate = new Date();
	var month = JobDate.getMonth() + 1;
	var day = JobDate.getDate();
	var year = JobDate.getFullYear();	
	h = JobDate.getHours();
	m = JobDate.getMinutes();
	s = JobDate.getSeconds();
	var TimelineJobDate = year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;

	var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
	var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s); 
	var msg_encrypt = hex_md5 (msg_source);		
	var a = msg_encrypt;
	var b = "-";
	var position1 = 8;
	var position2 = position1 + 4;
	var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');

    ///current = 1 : En route
    ///current = 2 : Stop Driving 
    ///current = 3 : Start Waiting
    ///current = 4 : Job Start
    ///current = 5 : job Stop
    ///current = 6 : Back Journey

	if(TimelineStepCount == "2") {
		
		//if(current_notification.timeline == null ) {


			db.transaction(function(tx) {
				tx.executeSql("insert into op_timestamp " +
						" values ('" + msg_encrypt_output + "' , '"+ current_notification.internal_id +"' , '" + TimelineJobDate  + "', '0', '0', '"+ TimelineJobDate + "', null, null, null, null, null, '" + $("#Text_TimelineDesc").val().replace("'", "''") + "', 'JS', '"+ current_login.user_id  +"', '0', '0' ) ;", [], "", errorCB);
			});

			db.transaction(function(tx) {
				tx.executeSql(" update op_notification set notification_status = 'E0005', notification_sapready = '1' where internal_id = '"+ current_notification.internal_id +"' ;", [], "", errorCB);
			});
			
			current_notification.timeline = new obj_notification(msg_encrypt_output);
			current_notification.timeline.internal_id = msg_encrypt_output;
			current_notification.timeline.job_date = TimelineJobDate;
			current_notification.timeline.job_travel_start = TimelineJobDate;

			var x = 0;
			while (x < ArrStatus.length)
			{
				
				if (ArrStatus[x] == 'E0005' ){ 
					current_notification.statusdesc = ArrStatusDesc[x];
					break;  // breaks out of loop completely
				}
				x = x + 1;
			  
			}
			$("#Tab_Invoice_JobStatus").text(current_notification.statusdesc);
			
			
			//current_tstamp_id = current_notification.timeline.internal_id;
			current_tstamp_id = msg_encrypt_output;
			
			TimelineStarted = true;
			TimelineStarted_notification_no = current_notification.notification_no;
			TimelineStarted_notificationid = current_notification.internal_id;
			
			$("#btn_job_finish").hide();  
			
			
			///reload left menu job list 
			RefreshLeftMenu();
			
			
		//} 
		
	} else if(TimelineStepCount == "3") {
		
		var JobDate = new Date();
		var month = JobDate.getMonth() + 1;
		var day = JobDate.getDate();
		var year = JobDate.getFullYear();
		h = JobDate.getHours();
		m = JobDate.getMinutes();
		s = JobDate.getSeconds();
		var JobTravelEnd = year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;

		var travelstart = new Date(current_notification.timeline.job_travel_start) , travelend = new Date(), diff  = new Date(travelend - travelstart), job_travel_count  = diff/1000/60/60;
		
		db.transaction(function(tx) {
			tx.executeSql("update op_timestamp set job_travel_end = '" + JobTravelEnd + "', job_travel = '" + job_travel_count.toFixed(2) + "', job_description =  '" + $("#Text_TimelineDesc").val().replace("'", "''") + "' where internal_id = '" + current_tstamp_id + "' ;", [], "", errorCB);
		});
		
		current_notification.timeline.job_travel_end = JobTravelEnd;
			
		
	} else if(TimelineStepCount == "4") {

		var JobDate = new Date();
		var month = JobDate.getMonth() + 1;
		var day = JobDate.getDate();
		var year = JobDate.getFullYear();
		h = JobDate.getHours();
		m = JobDate.getMinutes();
		s = JobDate.getSeconds();
		var JobWaitingStart = year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;

	
		db.transaction(function(tx) {
			tx.executeSql("update op_timestamp set job_waiting_start = '" + JobWaitingStart + "', job_description =  '" + $("#Text_TimelineDesc").val().replace("'", "''") + "' where internal_id = '" + current_tstamp_id + "' ;", [], "", errorCB);
		});
		
		current_notification.timeline.job_waiting_start = JobWaitingStart;
		
		
		
	} else if(TimelineStepCount == "5") {

		var waitingstart = new Date(current_notification.timeline.job_waiting_start) , waitingend = new Date(), diff  = new Date(waitingend - waitingstart), job_waiting_count  = diff/1000/60/60;

		var JobDate = new Date();
		var month = JobDate.getMonth() + 1;
		var day = JobDate.getDate();
		var year = JobDate.getFullYear();
		h = JobDate.getHours();
		m = JobDate.getMinutes();
		s = JobDate.getSeconds();
		var JobWaitingEnd = year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;

		
		db.transaction(function(tx) {
			tx.executeSql("update op_timestamp set job_waiting_end = '" + JobWaitingEnd + "', job_start = '" + JobWaitingEnd + "', job_waiting = '"+ job_waiting_count.toFixed(2) +"',  job_description =  '" + $("#Text_TimelineDesc").val().replace("'", "''") + "' where internal_id = '" + current_tstamp_id + "' ;", [], "", errorCB);
		});
		
		current_notification.timeline.job_waiting_end = JobWaitingEnd;
		current_notification.timeline.job_start = JobWaitingEnd;
		
		
	} else if(TimelineStepCount == "6") {

		var JobDate = new Date();
		var month = JobDate.getMonth() + 1;
		var day = JobDate.getDate();
		var year = JobDate.getFullYear();
		h = JobDate.getHours();
		m = JobDate.getMinutes();
		s = JobDate.getSeconds();
		var JobEnd = year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;

		db.transaction(function(tx) {
			tx.executeSql("update op_timestamp set job_end = '" + JobEnd + "', job_status = 'JE', job_description =  '" + $("#Text_TimelineDesc").val().replace("'", "''") + "' where internal_id = '" + current_tstamp_id + "' ;", [], "", errorCB);
		});
		
		current_notification.timeline.job_end = JobEnd;
		
		TimelineStarted = false;
		$("#btn_job_finish").show();  
		
		LoadFinalTab(); 
		
	} 

}

function UpdateBackJourney () {
	
	var JobComplete = new Date();
	var month = JobComplete.getMonth() + 1;
	var day = JobComplete.getDate();
	var year = JobComplete.getFullYear();
	h = JobComplete.getHours();
	m = JobComplete.getMinutes();
	s = JobComplete.getSeconds();
	var JobBackJourney = year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;

	var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
	var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s); 
	var msg_encrypt = hex_md5 (msg_source);		
	var a = msg_encrypt;
	var b = "-";
	var position1 = 8;
	var position2 = position1 + 4;
	var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');

	
	
	db.transaction(function(tx) {
		tx.executeSql("insert into  op_travelback values ('" + current_notification.internal_id + "',  '" + JobBackJourney + "', '" + JobBackJourney + "', '" + msg_encrypt_output + "' )  ;", [], "", errorCB);
	});
	
}

function btn_job_finish_click(){
	
	if (confirm(MessageConfirmFinish)) { 
		 // do things if OK

		var JobComplete = new Date();
		var month = JobComplete.getMonth() + 1;
		var day = JobComplete.getDate();
		var year = JobComplete.getFullYear();
		h = JobComplete.getHours();
		m = JobComplete.getMinutes();
		s = JobComplete.getSeconds();
		var JobBackJourney = year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;

		var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
		var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s);      
		var msg_encrypt = hex_md5 (msg_source);		
		var a = msg_encrypt;
		var b = "-";
		var position1 = 8;
		var position2 = position1 + 4;
		var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');

		
		/// tp update notification status = E0009
			
		db.transaction(function(tx) {
			tx.executeSql("update op_notification set notification_status = 'E0009', notification_sapready = '1' where internal_id =  '" + current_notification.internal_id + "' ;", [], "", errorCB);
		});

		array_notifications = [];
		LoadNotifications();
		LoadNotificationDetail(current_notification.internal_id);
		
		alert("Job finish"); 
		
		
	}
	
}


function btn_job_travel_start_back_click() {
	
	var JobComplete = new Date();
	var month = JobComplete.getMonth() + 1;
	var day = JobComplete.getDate();
	var year = JobComplete.getFullYear();
	h = JobComplete.getHours();
	m = JobComplete.getMinutes();
	s = JobComplete.getSeconds();
	var JobStartJourney = year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;

	var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
	var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s );      
	var msg_encrypt = hex_md5 (msg_source);		
	var a = msg_encrypt;
	var b = "-";
	var position1 = 8;
	var position2 = position1 + 4;
	var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');

	
	
	db.transaction(function(tx) {
		tx.executeSql("insert into  op_travelback values ('" + current_notification.internal_id + "',  '" + JobStartJourney + "', '', '" + msg_encrypt_output + "' )  ;", [], "", errorCB);
	});
	
	alert("Travel Back Start"); 
	
	
}

function btn_job_travel_end_back_click() {
	
	var JobComplete = new Date();
	var month = JobComplete.getMonth() + 1;
	var day = JobComplete.getDate();
	var year = JobComplete.getFullYear();
	h = JobComplete.getHours();
	m = JobComplete.getMinutes();
	s = JobComplete.getSeconds();
	var JobBackJourney = year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;

	var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
	var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s); 
	var msg_encrypt = hex_md5 (msg_source);		
	var a = msg_encrypt;
	var b = "-";
	var position1 = 8;
	var position2 = position1 + 4;
	var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');

	
	
	db.transaction(function(tx) {
		tx.executeSql("update op_travelback set time_end = '"+ JobBackJourney +"' where  notification_id = '" + current_notification.internal_id + "' ;", [], "", errorCB);
	});
	
	alert("Travel Back End"); 
	
}

//*** END Timeline

// ********************************************************************************************************************

//*** BEGIN Damages / Causes

// ClearDamage
// Called when loading another notification
// by Victor Tai 
function ClearDamage () {
$("#" + TAB_DAMAGECAUSE_TABLE_DAMAGE + " tr:gt(0)").remove();
}

// AddDamage
// by Victor Tai 
function AddDamage (array_damages) {
	
	var str = "";
	for (var x = 0; x < array_damages.length; x++) {

	    str = str + "<tr  id='" + array_damages[x].internal_id + "'>";

	    str = str + "<td>" + array_damages[x].damage_code_desc + "</td>";
		str = str + "<td>" + current_notification.equipment.equipmentdesc + "</td>";
	    str = str + "<td>" + array_damages[x].damage_group_desc + "</td>";
	    str = str + "<td>" + array_damages[x].damage_desc + "</td>";
	    str = str +  "<td><a onclick=\"return DeleteDamage('" + array_damages[x].internal_id + "', '" + array_damages[x].damage_code + " / " + array_damages[x].damage_group + "');\">Delete</a></td>";
	    if(array_damages[x].op_sys == 0){
	    	str = str +  "<td><a onclick=\"return EditDamage('" + array_damages[x].internal_id + "', '" + array_damages[x].damage_group + "', '" + array_damages[x].damage_code + "', '" + array_damages[x].damage_desc + "');\" href='#modal_edit_damage' data-toggle='modal' >Edit</a></td>";
	    } else {
	    	str = str +  "<td></td>";
	    }
	    	
	    str = str + "</tr>";
	    
	    $("#" + TAB_DAMAGECAUSE_TABLE_DAMAGE + " tr:last").after(str);
	    str = "";
	}

}

// UpdateDamage
// by Victor Tai
function UpdateDamage (id, code, group, desc) {

// update from database here

var str = "<td>" + code + "</td>";
str += "<td>" + group + "</td>";
str += "<td>" + desc + "</td>";
str += "<td><a onclick=\"return DeleteDamage('" + id + "', '" + code + " / " + group + "');\">Delete</a></td>";	


$("#" + id).html(str);
}

function EditDamage(damage_id, damage_grp, damage_code, desc) {

	CurEditDamageID = damage_id; 
	CurEditDamageCode = damage_code; 
	
	var str = "";

	$("#Edit_DamageDescription_text").val(desc);
	
	if(array_master_damages.length > 0) {
		
		//ClearMasterDamage();
		$("#" + DRP_EDIT_DAMAGEGROUP + " option:gt(0)").empty();
		
	
		for (var x = 0; x < array_master_damages.length; x++) {
			
			if(array_master_damages[x].master_id == damage_grp) {
				str = str + "<option value='" + array_master_damages[x].master_id + "' selected>"  + array_master_damages[x].master_desc;
			} else {
				str = str + "<option value='" + array_master_damages[x].master_id + "' >"  + array_master_damages[x].master_desc;
			}
			
			str = str + "</option>";

		    $("#" + DRP_EDIT_DAMAGEGROUP + " option:last").after(str);
		    
		    str = "";
		}
		
		LoadEditDamageCode(damage_grp);

	}
	
}

function BuildDamageGroupDrp(tx, results) {
	
	var len = results.rows.length;
   	
	if (len > 0) {
   		
		for (var i=0; i< len; i++) {  

   			current_notification.array_master_damages = array_master_damages[i];
   			array_master_damages[i] = results.rows.item(i);
   		}

	}
	

}


// DeleteDamage
// by Victor Tai 
function DeleteDamage(id, desc) {

if (confirm("Are you sure you want to delete this damage: " + desc + "?")) {
    
    // delete from database here
	db.transaction(function(tx) {
		tx.executeSql("delete from op_damages where internal_id  =  '" + id + "';", [], $("#" + id).remove(), errorCB);
	});

	tx.executeSql("select op_damages.*, master_damage.damage_desc as damage_code_desc, master_lookup.master_desc as damage_group_desc" +
			" from op_damages inner join master_damage on  master_damage.damage_group = op_damages.damage_group and master_damage.damage_code = op_damages.damage_code" +
			" inner join master_lookup on master_lookup.master_id = op_damages.damage_group " +
			" where master_lookup.master_type = 'DAMAGEGROUP' and damage_notification = '" + current_notification.internal_id + "' ;", [], ReLoadDamages_querySuccess, errorCB);

	}

}





// ClearCause
// Called when loading another notification
// by Victor Tai 

function ClearCause() {

	$("#" + TAB_DAMAGECAUSE_TABLE_CAUSE + " tr:gt(0)").remove();

}     

// AddCause
// by Victor Tai 
function AddCause (array_causes) {

	var str = "";

	for (var x = 0; x < array_causes.length; x++) {
	    
	    str = str + "<tr id='" + array_causes[x].internal_id + "'>";
	    str = str + "<td>" + array_causes[x].cause_code_desc + "</td>";
	    str = str + "<td>" + array_causes[x].cause_group_desc + "</td>";
	    str = str + "<td>" + array_causes[x].cause_desc + "</td>";
	    str = str +  "<td><a onclick=\"return DeleteCause('" + array_causes[x].internal_id + "', '" + array_causes[x].cause_code + " / " + array_causes[x].cause_group + "');\">Delete</a></td>";
	    
	    if(array_causes[x].op_sys == 0){
	    	str = str +  "<td><a onclick=\"return EditCause('" + array_causes[x].internal_id + "', '" + array_causes[x].cause_group + "', '" +  array_causes[x].cause_code + "', '" + array_causes[x].cause_desc + "');\" href='#modal_edit_cause' data-toggle='modal' >Edit</a></td>";
	    } else {
	    	str = str +  "<td></td>";
	    }
	    	
	    
	    str = str + "</tr>";
	    
	    $("#" + TAB_DAMAGECAUSE_TABLE_CAUSE + " tr:last").after(str);
	    str = "";
	}

}

function EditCause(cause_id, cause_grp, cause_code, desc) {

	CurEditCauseID = cause_id; 
	CurEditCauseCode = cause_code ;
	
	var str = "";

	$("#Edit_CauseDescription_text").val(desc);

	if(array_master_causes.length > 0) {
		
		//ClearMasterDamage();
		$("#" + DRP_EDIT_DAMAGEGROUP + " option:gt(0)").remove();
		
		//BuildMasterDamage(array_master_damages);

		for (var x = 0; x < array_master_causes.length; x++) {
			if(array_master_causes[x].master_id == cause_grp ) {
				str = str + "<option value='" + array_master_causes[x].master_id + "' selected>"  + array_master_causes[x].master_desc;
			} else {
				str = str + "<option value='" + array_master_causes[x].master_id + "' >"  + array_master_causes[x].master_desc;
			}
			
			str = str + "</option>";

		    $("#" + DRP_EDIT_CAUSEGROUP + " option:last").after(str);
		    
		    str = "";
		}

		LoadEditCauseCode(cause_grp);
	}
	
}


// UpdateCause
// by Victor Tai
function UpdateCause (id, code, group, desc) {

// update from database here

var str = "<td>" + code + "</td>";
str += "<td>" + group + "</td>";
str += "<td>" + desc + "</td>";
str += "<td><a onclick=\"return DeleteCause('" + id + "', '" + code + " / " + group + "');\">Delete</a></td>";	


$("#" + id).html(str);
}    

// DeleteCause
// by Victor Tai 
function DeleteCause(id, desc) {
if (confirm("Are you sure you want to delete this cause: " + desc + "?")) {
    
    // delete from datatabase here
	db.transaction(function(tx) {
		tx.executeSql("delete from op_causes where internal_id  =  '" + id + "';", [], $("#" + id).remove(), errorCB);
	});
	
	db.transaction(function(tx) {
		tx.executeSql("select op_causes.*, master_cause.cause_desc as cause_code_desc, master_lookup.master_desc as cause_group_desc" +
				" from op_causes inner join master_cause on  master_cause.cause_group = op_causes.cause_group and master_cause.cause_code = op_causes.cause_code " +
				" inner join master_lookup on master_lookup.master_id = op_causes.cause_group  " +
				" where master_lookup.master_type = 'CAUSEGROUP' and cause_notification = '" + current_notification.internal_id + "' ;", [], ReLoadCauses_querySuccess, errorCB);
	});
	
	

    
}	
}



//*** END Damages / Causes

// ********************************************************************************************************************
//*** BEGIN Left Notificaqtion List - clear job listing 

//ClearList
function ClearJobListing () {
	$("#" + TAB_NOTIFICATION_LIST + " li:gt(0)").remove();
	
}

function BuildJobList (array_notifications) {


	ClearList();
	var bgcolor = "";
	///#4D94FF = blue , #FF8566 = red , #00cc66 = green

	var str = "";

	
	
	for (var x = 0; x < array_notifications.length; x++) {
		if(array_notifications[x].notification_status ==  "E0001"){
			bgcolor = "#4D94FF";
		}
		else if(array_notifications[x].notification_status ==  "E0003"){
			 bgcolor = "#4D94FF";
		}
		else if(array_notifications[x].notification_status ==  "E0004"){
			 bgcolor = "#4D94FF";
		}
		else if(array_notifications[x].notification_status ==  "E0005"){
			 //bgcolor = "#FF8566";-- in V3
			 bgcolor = "#ffb848";
		}
		else if(array_notifications[x].notification_status ==  "E0015"){
			 bgcolor = "#4D94FF";
		}
		else if(array_notifications[x].notification_status ==  "E0009"){
			 bgcolor = "#00cc66";
		}
		else{
			 bgcolor = "#4D94FF";
		}
		
	    str = "<li style='background-color: "+ bgcolor +"' id='"+ array_notifications[x].internal_id +"' >";
	    
	    str = str + "<a href='notification_detail.html?uid=" + current_login.user_id  + "&lid=" + SelectedLanguageID + "&jid=" + array_notifications[x].internal_id + "&sid=" + SelectedStatus + " '> <i style='float: left;' class='icon-th-list'></i>";
	    str = str + "<span class='title'>" + array_notifications[x].notification_no + " | " + array_notifications[x].notification_subject + "</span> ";
	    str = str + "<span id='job_status_date' style='float: right;' class='title'> | " + array_notifications[x].master_desc + " | " + array_notifications[x].notification_requiredstart.substring(0,10) + "</span> <br><br>";
	    str = str + "</a>";
	    str = str + "</li>";
		
		$("#Tab_NotificationList").append(str);
	}
	
	 
}

function RefreshLeftMenu(){

	$("ul#Tab_NotificationList li#" + current_notification.internal_id).find('span#job_status_date').text("In Process | " + current_notification.requirestart.substring(0,10));
	
	$("ul#Tab_NotificationList li#" + current_notification.internal_id).css("background-color","#FF8566");
	
	
}



function BuildCalendar() {
	
	var jsonArr = [];
	var joblist = ""; 
	
	if(array_notifications.length > 0) {
    	
        for (var x = 0; x < array_notifications.length; x++) {  
        	var date = new Date(array_notifications[x].notification_requiredstart);
            var d = date.getDate();
            var m = date.getMonth() ;
            var y = date.getFullYear();


        	jsonArr.push({
        		title: array_notifications[x].notification_subject,  start: new Date(y, m, d)
            });

        	
        }
	}

	 var date = new Date();
     var d = date.getDate();
     var m = date.getMonth();
     var y = date.getFullYear();

     var h = {};

     if ($('#calendar').width() <= 500) {
         $('#calendar').addClass("mobile");
         h = {
             left: 'title, prev, next',
             center: '',
             right: 'today,month,agendaWeek,agendaDay'
         };
     } else {
         $('#calendar').removeClass("mobile");
         h = {
             left: 'title',
             center: '',
             right: 'prev,next,today,month,agendaWeek,agendaDay'
         };
     }

     $('#calendar').fullCalendar('destroy'); // destroy the calendar
     $('#calendar').fullCalendar({ //re-initialize the calendar
         disableDragging: false,
         header: h,
         editable: true,
         events: jsonArr
     });

}


function ClearMasterDamage(){
	$("#" + DRP_DAMAGEGROUP + " option:gt(0)").remove();
	
	
}


function ClearMasterCause(){
	$("#" + DRP_CAUSEGROUP + " option:gt(0)").remove();
	
	
}

function ClearCheckListType(){
	$("#" + DRP_CHECKLISTTYPE + " option:gt(0)").remove();
	
	
}

function BuildMasterDamage(array_master_damages){
	
	var str = "";

	for (var x = 0; x < array_master_damages.length; x++) {
		str = str + "<option value='" + array_master_damages[x].master_id + "' >"  + array_master_damages[x].master_desc;
		str = str + "</option>";

	    $("#" + DRP_DAMAGEGROUP + " option:last").after(str);
	    
	    str = "";
	}

}

function BuildMasterCause(array_master_causes){
	
	
	
	var str = "";

	for (var x = 0; x < array_master_causes.length; x++) {
		str = str + "<option value='" + array_master_causes[x].master_id + "' >"  + array_master_causes[x].master_desc;
		str = str + "</option>";

	    $("#" + DRP_CAUSEGROUP + " option:last").after(str);
	    
	    str = "";
	}

}

function ClearDamageCode(){
	
	$("#" + DRP_DAMAGECODE + " option:gt(0)").remove();
	
}

function ClearCauseCode(){
	
	$("#" + DRP_CAUSECODE + " option:gt(0)").remove();
	
}

function BuildDamageCode(array_master_damagecode){
	
	var str = "";

	for (var x = 0; x < array_master_damagecode.length; x++) {
		str = str + "<option value='" + array_master_damagecode[x].damage_code + "' >"  + array_master_damagecode[x].damage_desc;
		str = str + "</option>";

	    $("#" + DRP_DAMAGECODE + " option:last").after(str);
	    
	    str = "";
	    
	    LatestDamageOrder = (array_master_damagecode[x].damage_order > LatestDamageOrder) ? array_master_damagecode[x].damage_order : LatestDamageOrder;
	}

	LatestDamageOrder = LatestDamageOrder + 1;
	
}

function BuildCauseCode(array_master_causecode){
	
	var str = "";

	for (var x = 0; x < array_master_causecode.length; x++) {
		str = str + "<option value='" + array_master_causecode[x].cause_code + "' >"  + array_master_causecode[x].cause_desc;
		str = str + "</option>";

	    $("#" + DRP_CAUSECODE + " option:last").after(str);
	    
	    str = "";
	    
	    LatestCauseOrder = (array_master_causecode[x].cause_order > LatestCauseOrder) ? array_master_causecode[x].cause_order : LatestCauseOrder;
	}

	LatestCauseOrder = LatestCauseOrder + 1;
	
}

function checkexist_opdamages(){
	
	
	
	var isexist = false; 
	
	var a = document.getElementById("Dropdown_DamageGroup");
	var strdamagegroup = a.options[a.selectedIndex].value;
	
	var b = document.getElementById("Dropdown_DamageCode");
	var strdamagecode = b.options[b.selectedIndex].value;
	
	var strdamagedesc = $("#DamageDescription_text").val();
	
	//check if exist data
	db.transaction(function(tx) {
		tx.executeSql("select * from op_damages where damage_code = '" + strdamagecode + "' and damage_group = '" + strdamagegroup + "' and damage_notification = '"+  current_notification.internal_id +"' ;", [], 
				function (tx, results){ if (results.rows.length > 0) {isexist = true;} else {isexist = false}}, 
				errorCB);
	});

	
	//insert into db; table name = op_damages
	if(isexist){
		alert(MessageForAlreadyExists);
		//update
	}
	else{

		var TempDate = new Date();
		var month = TempDate.getMonth() + 1;
		var day = TempDate.getDate();
		var year = TempDate.getFullYear();
		h = TempDate.getHours();
		m = TempDate.getMinutes();
		s = TempDate.getSeconds();
		
		var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
		var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s); 
		var msg_encrypt = hex_md5 (msg_source);		
		var a = msg_encrypt;
		var b = "-";
		var position1 = 8;
		var position2 = position1 + 4;
		var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');

		db.transaction(function(tx) {
			tx.executeSql("insert into op_damages values " +
					"('" + msg_encrypt_output + "' , '" + current_notification.internal_id + "' , '" + strdamagegroup + "' , '" + strdamagecode + "', '" + strdamagedesc + "' , '"+ LatestDamageOrder +"', 0 );", [], LoadOpDamageTable,  errorCB);
		});
		

	}
	
	
}

function update_opdamages () {
	
	
	var isexist = false; 
	
	var a = document.getElementById("Dropdown_Edit_DamageGroup");
	var strdamagegroup = a.options[a.selectedIndex].value;
	
	var b = document.getElementById("Dropdown_Edit_DamageCode");
	var strdamagecode = b.options[b.selectedIndex].value;
	
	var strdamagedesc = $("#Edit_DamageDescription_text").val();

	db.transaction(function(tx) {
		tx.executeSql("update op_damages set damage_group = '" + strdamagegroup + "' , damage_code = '" + strdamagecode + "', damage_desc = '"+ strdamagedesc + 
				"' where internal_id = '"+ CurEditDamageID +"';", [],  ReLoadOpDamageTable,  errorCB);
	});
	
}


function LoadOpDamageTable(tx){
	
	alert(MessageForUpdateSuccess); 
	
	tx.executeSql("select op_damages.*, master_damage.damage_desc as damage_code_desc, master_lookup.master_desc as damage_group_desc" +
			" from op_damages inner join master_damage on  master_damage.damage_group = op_damages.damage_group and master_damage.damage_code = op_damages.damage_code" +
			" inner join master_lookup on master_lookup.master_id = op_damages.damage_group " +
			" where master_lookup.master_type = 'DAMAGEGROUP' and damage_notification = '" + current_notification.internal_id + "' order by damage_code_desc ;", [], ReLoadDamages_querySuccess, errorCB);

   
	
    
}


function ReLoadOpDamageTable(tx){
	
	alert("Damage update successfully"); 
	
	tx.executeSql("select op_damages.*, master_damage.damage_desc as damage_code_desc, master_lookup.master_desc as damage_group_desc" +
			" from op_damages inner join master_damage on  master_damage.damage_group = op_damages.damage_group and master_damage.damage_code = op_damages.damage_code" +
			" inner join master_lookup on master_lookup.master_id = op_damages.damage_group " +
			" where master_lookup.master_type = 'DAMAGEGROUP' and damage_notification = '" + current_notification.internal_id + "' ordre by damage_code_desc ;", [], ReLoadDamages_querySuccess, errorCB);

}

function ReLoadDamages_querySuccess(tx, results){
	
	array_damages = [];
	
	//if (array_damages.length == 0) {
	if(results.rows.length > 0) {

		var len = results.rows.length;
		
		for (var i=0; i< len; i++) {  

			current_notification.array_damages = array_damages[i];
			array_damages[i] = results.rows.item(i);
		}
		
		ClearDamage();
		AddDamage(array_damages);
   }
	
	 ///here to reload summary
	ReLoadSummaryTab();
	
	document.getElementById('Button_Add_Damage_Back').click(); 
	document.getElementById('Button_Edit_Damage_Back').click(); 
	
	
	
}

function LoadOpCauseTable(tx){
alert(MessageForUpdateSuccess); 
	
	tx.executeSql("select op_damages.*, master_damage.damage_desc as damage_code_desc, master_lookup.master_desc as damage_group_desc" +
			" from op_damages inner join master_damage on  master_damage.damage_group = op_damages.damage_group and master_damage.damage_code = op_damages.damage_code" +
			" inner join master_lookup on master_lookup.master_id = op_damages.damage_group " +
			" where master_lookup.master_type = 'DAMAGEGROUP' and damage_notification = '" + current_notification.internal_id + "' ;", [], ReLoadCauses_querySuccess, errorCB);

}

function ReLoadOpCauseTable(tx){
	
	alert("Cause update successfully"); 

	tx.executeSql("select op_damages.*, master_damage.damage_desc as damage_code_desc, master_lookup.master_desc as damage_group_desc" +
				" from op_damages inner join master_damage on  master_damage.damage_group = op_damages.damage_group and master_damage.damage_code = op_damages.damage_code" +
				" inner join master_lookup on master_lookup.master_id = op_damages.damage_group " +
				" where master_lookup.master_type = 'DAMAGEGROUP' and damage_notification = '" + current_notification.internal_id + "' ;", [], ReLoadCauses_querySuccess, errorCB);

	}


function checkexist_opcauses(){
	
	
	var isexist = false; 

	MessageForNotAbleToUpdate = "Cause not able to create";
	MessageForAlreadyExists = "Cause already exist";
	//MessageForUpdateSuccess = "Cause added successfully";
	MessageForValidateDescription = "Please enter a Description for Cause";


	var a = document.getElementById(DRP_CAUSEGROUP);
	var strcausegroup = a.options[a.selectedIndex].value;
	
	var b = document.getElementById(DRP_CAUSECODE);
	var strcausecode = b.options[b.selectedIndex].value;
	
	var strcausedesc = $("#CauseDescription_text").val();
	
	//check if exist data
	db.transaction(function(tx) {
		tx.executeSql("select * from op_causes where cause_code = '" + strcausecode + "' and cause_group = '" + strcausegroup + "' and cause_notification = '"+  current_notification.internal_id +"' ;", [], 
				function (tx, results){ if (results.rows.length > 0) {isexist = true;} else {isexist = false}}, 
				errorCB);
	});

	
	//insert into db; table name = op_damages
	if(isexist){
		alert(MessageForAlreadyExists);
		//update
	}
	else{


		var TempDate = new Date();
		var month = TempDate.getMonth() + 1;
		var day = TempDate.getDate();
		var year = TempDate.getFullYear();
		h = TempDate.getHours();
		m = TempDate.getMinutes();
		s = TempDate.getSeconds();
		
		var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
		var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s); 
		var msg_encrypt = hex_md5 (msg_source);		
		var a = msg_encrypt;
		var b = "-";
		var position1 = 8;
		var position2 = position1 + 4;
		var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');


		db.transaction(function(tx) {
			tx.executeSql("insert into op_causes values " +
					"('" + msg_encrypt_output + "' , '" + current_notification.internal_id + "' , '" + strcausegroup + "' , '" + strcausecode + "', '" + strcausedesc + "' , '"+ LatestCauseOrder +"', 0 );", [], LoadOpCauseTable,  errorCB);
		});
		
	}
	
}

function LoadOpCauseTable(tx){
	
	alert("Cause added successfully"); 

	tx.executeSql("select op_causes.*, master_cause.cause_desc as cause_code_desc, master_lookup.master_desc as cause_group_desc" +
			" from op_causes inner join master_cause on  master_cause.cause_group = op_causes.cause_group and master_cause.cause_code = op_causes.cause_code " +
			" inner join master_lookup on master_lookup.master_id = op_causes.cause_group  " +
			" where master_lookup.master_type = 'CAUSEGROUP' and cause_notification = '" + current_notification.internal_id + "' order by cause_code_desc ;", [], ReLoadCauses_querySuccess, errorCB);

    
}

function ReLoadCauses_querySuccess(tx, results){
	
	array_causes = [];
	
	//if (array_causes.length == 0) {
	if(results.rows.length > 0) {

		var len = results.rows.length;
   	
		for (var i=0; i< len; i++) {  

			current_notification.array_causes = array_causes[i];
			array_causes[i] = results.rows.item(i);
		}
		
		ClearCause();
		AddCause(array_causes);
   }
	
	 ///here to reload summary
	ReLoadSummaryTab();
	
	document.getElementById('Button_Add_Cause_Back').click(); 
	document.getElementById('Button_Edit_Cause_Back').click(); 
	
	
}


function update_opcauses () {
	
	
	var isexist = false; 
	
	var a = document.getElementById("Dropdown_Edit_CauseGroup");
	var strcausegroup = a.options[a.selectedIndex].value;
	
	var b = document.getElementById("Dropdown_Edit_CauseCode");
	var strcausecode = b.options[b.selectedIndex].value;
	
	var strcausedesc = $("#Edit_CauseDescription_text").val();
	
	db.transaction(function(tx) {
		tx.executeSql("update op_causes set cause_group = '" + strcausegroup + "' , cause_code = '" + strcausecode + "', cause_desc = '"+ strcausedesc + 
				"' where internal_id = '"+ CurEditCauseID +"';", [],  ReLoadOpCauseTable,  errorCB);
	});

	
}


//********************************************************************************************************************
/// BEGIN Parts Tab 
function BuildPartsTable(current_part) {
	
	
	
	
	var str = "";
	var MaterialNo = "";
	
	
	 $("#" + TAB_PARTS_TABLE + " tr:gt(0)").remove();
	 
	for (var x = 0; x < current_part.length; x++) {
	    
	    str = str + "<tr id='" + current_part[x].internal_id + "'>";
	   
	    if(current_part[x].part_material.length > 0 && current_part[x].part_material != "NULL" ) {
	    	MaterialNo = current_part[x].part_material;
	    	str = str + "<td>" + current_part[x].part_material + "</td>";
	    } else {
	    	MaterialNo = "";
	    	str = str + "<td></td>";
	    }

	    str = str + "<td>" + current_part[x].part_material_desc + "</td>";
	    str = str + "<td>" + current_part[x].part_quantity + "</td>";
	    str = str + "<td>" + current_part[x].part_consumed + "</td>";
	    str = str + "<td>" + current_part[x].part_reserved + "</td>";
	    str = str + "<td>" + current_part[x].part_unit + "</td>";

	   /* if (current_part[x].op_updated_from_sap != "2") {
	    	
	    	if(current_part[x].op_updated_from_sap == "1") {
	    		str = str + "<td>&nbsp;</td>";
	    	} else {
	    		str = str +  "<td><a onclick=\"return DeletePart('" + current_part[x].internal_id + "', '" + current_part[x].part_material_desc + "');\" >Delete</a></td>";
	    	}
	    	
	    	//str = str + "<td>&nbsp;</td>";
	    	str = str +  "<td><a onclick=\"return EditPart('" +  current_part[x].internal_id + "', '" + MaterialNo + "', '" + current_part[x].part_unit + "', '" +  current_part[x].part_consumed + "', '" + current_part[x].part_quantity + "', '" + 
		    current_part[x].part_reserved + "', '" + current_part[x].part_material_desc + "', '" + current_part[x].op_updated_from_sap + "');\" href='#modal_edit_part' data-toggle='modal' >Edit</a></td>";
		    
	    } else {
	    	str = str + "<td>&nbsp;</td>";
	    	str = str + "<td>&nbsp;</td>";
	    	
	    }  hided for V4*/ 
	    
	    str = str + "</tr>";	    
	    $("#" + TAB_PARTS_TABLE + " tr:last").after(str);
	        
	    str = "";

	}
	
	  $("table#" + TAB_PARTS_TABLE + " tr#0").remove();

}

function EditPart (partid, selected_MaterialNo, selected_part_unit, selected_part_consumed, selected_part_quantity, selected_part_reserved, selected_part_material_desc, selected_part_status ) {

	selected_partid = partid;
	
	//txt_edit_partno
	$('#txt_edit_partno').val(selected_MaterialNo);
	$('#txt_edit_unit').val(selected_part_unit);
	$('#txt_edit_consumed').val(selected_part_consumed);
	$('#txt_edit_quantity').val(selected_part_quantity);
	$('#txt_edit_reserved').val(selected_part_reserved);
	$('#txt_edit_material_desc').val(selected_part_material_desc);
	
	if (selected_part_status == "1" ) {
		$("#txt_edit_consumed").prop('disabled',false);
	} 
	
	if (selected_part_status == "0" ) {
		$("#txt_edit_unit").prop('disabled',false);
		$("#txt_edit_consumed").prop('disabled',false);
		$("#txt_edit_material_desc").prop('disabled',false);
	} 
	
	
}

function DeletePart (part_id, MaterialDesc) {
	
	if (confirm("Are you sure you want to delete this part: " + MaterialDesc + "?")) {
	    
		// delete from database here
		
		db.transaction(function(tx) {
			tx.executeSql("delete from op_parts where internal_id  =  '" + part_id + "';", [], $("#" + part_id).remove(), errorCB);
		});
 
		 

	}
	
}

function LoadPartDetail (PartID) {
	alert("PartID " + PartID); 
}



//********************************************************************************************************************
//*** BEGIN CheckList Tab

function ClearCheckList() {




	$("#" + TAB_CHECKLIST_TABLE + " tr:gt(0)").remove();

} 

function BuildCheckList(array_checklist){

	var str = "";


	for (var x = 0; x < array_checklist.length; x++) {
	    
	    str = str + "<tr id='" + array_checklist[x].internal_id + "'>";
	    str = str + "<td>" + array_checklist[x].checklist_question + "</td>";
	   
	    if(array_checklist[x].checklist_answer === undefined || array_checklist[x].checklist_answer == 'NULL' ){
	    	str = str + "<td class='hidden-480'><input class='m-wrap medium' type='text' placeholder='Test Result..' /> </td>";
	    }
	    else{
	    	
	    	str = str + "<td class='hidden-480'><input class='m-wrap medium' type='text' value='"+ array_checklist[x].checklist_answer +"' /> </td>";
	    	
	    }

	    str = str + "<td > <span class='label label-success' onclick=\"return myFunction('" + array_checklist[x].internal_id + "');\" > <i class='icon-edit'></i>  Done  </span></td>";
	    	    
	    str = str + "</tr>";
	    if (x== 0) {
	    	$("#" + TAB_CHECKLIST_TABLE + " > tbody:last").append(str);
	    } else {
	    	$("#" + TAB_CHECKLIST_TABLE + " tr:last").after(str);
	    }
	    
	        
	    str = "";
	}
	
	  
}

function myFunction(SelectedRowID) {
	
	$("table#" + TAB_CHECKLIST_TABLE + " tr#" + SelectedRowID).find('td').eq(1).find('input').val("Done");

}

function checklist_save(){

	///$('body').isLoading({ text: "Update Checklist..." });
	
	//1. delete from op_checklist_header 
	//console.log("TCHECKQUERY"+"delete from op_checklist_header where internal_id  =  '" + SelectedCheckListHeaderID);
	if (SelectedCheckListHeaderID.length > 0 ) {
		
		db.transaction(function(tx) {
			tx.executeSql("delete from op_checklist_header where internal_id  =  '" + SelectedCheckListHeaderID + "';", [], Create_Op_ChecklistHeader, errorCB);
		});
	} else {
		Create_Op_ChecklistHeader();
	}
	

}



function Create_Op_ChecklistHeader(){
	

	var TempDate = new Date();
	var month = TempDate.getMonth() + 1;
	var day = TempDate.getDate();
	var year = TempDate.getFullYear();
	h = TempDate.getHours();
	m = TempDate.getMinutes();
	s = TempDate.getSeconds();
	
	var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
	//var msg_source = PrepareKey(keys[rindex], current_login.user_id );  
	var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s); 
	var msg_encrypt = hex_md5 (msg_source);		
	var a = msg_encrypt;
	var b = "-";
	var position1 = 8;
	var position2 = position1 + 4;
	var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');

	if (SelectedCheckListHeaderID.length > 0 ) {
		msg_encrypt_output = SelectedCheckListHeaderID;
	}
	
	var AcquisitionModelNo = ""; 
	var AcquisitionSN = ""; 
	var CheckListDate = Date(); 
	var Department = "";
	var HospitalName = $("#lbl_CheckList_HospitalName").text(); 
	var ModelNo = $("#lbl_CheckList_ModelNo").text(); 
	var Notification = current_notification.internal_id;
	var SN = $("#lbl_CheckList_SN").text(); 
	var TreadmillModelNo = ""; 
	var TreadmillSN = ""; 
	
	var a = document.getElementById(DRP_CHECKLISTTYPE);
	var CheckListType = a.options[a.selectedIndex].value;
	
	
	
	var CheckListDate = new Date();
	var month = currentTime.getMonth() + 1;
	var day = currentTime.getDate();
	var year = currentTime.getFullYear();
	h = currentTime.getHours();
	m = currentTime.getMinutes();
	s = currentTime.getSeconds();
	CheckListDate = year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;

	db.transaction(function(tx) {
		tx.executeSql("insert into op_checklist_header values ('" + msg_encrypt_output + "' , '" + current_notification.internal_id + "' , '" + HospitalName + 
				"' , '" + ModelNo + "', '" + SN + "' , '"+ CheckListDate +"', '"+ AcquisitionModelNo+"', '"+ AcquisitionSN +"', '" + TreadmillModelNo + 
				"', '" + TreadmillSN + "', '" + Department + "',  '" + CheckListType + "' );" , [], Create_Op_detail(msg_encrypt_output),  errorCB);
	});
	
	
	
	
}

function Create_Op_detail(checklist_header_id){

	//looping to read each edited text in the detail table
	var rowCount = $("#" + TAB_CHECKLIST_TABLE + " tr").length;

	var table = $("#" + TAB_CHECKLIST_TABLE + " tbody");
   
    table.find('tr').each(function (i) {

    	var checklistdetailid = $(this).attr('id'); 

		var TempDate = new Date();
		var month = TempDate.getMonth() + 1;
		var day = TempDate.getDate();
		var year = TempDate.getFullYear();
		h = TempDate.getHours();
		m = TempDate.getMinutes();
		s = TempDate.getSeconds();
		
    	var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
    	var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s);    
    	var msg_encrypt = hex_md5 (msg_source);		
    	var a = msg_encrypt;
    	var b = "-";
    	var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');

        var $tds = $(this).find('td');
        var ChecklistDesc = $tds.eq(0).text();
        var test_result = $tds.eq(1).find('input').val();

    	if (SelectedCheckListHeaderID.length > 0 ) { 
    		//alert("insert1");
    		db.transaction(function(tx) {
        		tx.executeSql("update op_checklist_detail set checklist_answer = '" + test_result + "' where internal_id = '" + checklistdetailid + "'  ;", [], "",  errorCB);
        	}); 
    	} else {
    		//alert("insert2");
    		db.transaction(function(tx) {
        		tx.executeSql("insert into op_checklist_detail values " +
        				"('" + msg_encrypt_output + "' , '" + checklist_header_id + "' , '" + checklistdetailid + "' , '" + test_result + "' );", [], "",  errorCB);
        	}); 
    	}
    	
    	
        
    });
    

	//db.transaction(function(tx) {
		//tx.executeSql("SELECT op_checklist_detail.*, master_checklist.checklist_question FROM op_checklist_detail " +
			//	"inner join master_checklist  on master_checklist.internal_id = op_checklist_detail.checklist_id " +
				//"WHERE op_checklist_detail.checklist_header_id = (select op_checklist_header.internal_id from op_checklist_header " +
				//"where notification_id = '" + current_notification.internal_id + "') ;", [], ReLoadChecklistData_Template, errorCB);
	//});


	var a = document.getElementById(DRP_CHECKLISTTYPE);
	var strchecklisttype = a.options[a.selectedIndex].value;
	
	
	
	db.transaction(function(tx) {
		tx.executeSql("SELECT op_checklist_detail.*, master_checklist.checklist_question FROM op_checklist_detail " +
				"inner join op_checklist_header on op_checklist_header.internal_id = op_checklist_detail.checklist_header_id " +
				"inner join master_checklist on master_checklist.checklist_type = op_checklist_header.checklist_type " +
				"WHERE op_checklist_header.notification_id  = '" + current_notification.internal_id + "' ;", [], ReLoadChecklistData_Template, errorCB);
	});

	
    alert("Checklist successfully updated"); 
    
 
}




//********************************************************************************************************************
//*** BEGIN Quotation Tab

function LoadConfirmQuotation(tx){
	

	tx.executeSql("SELECT * FROM op_quotation WHERE quotation_notification = '" + current_notification.internal_id + "' AND quotation_status = '1' ;", [], LoadConfirmQuotation_querySuccess, errorCB);
	
}

function LoadConfirmQuotation_querySuccess(tx, results){
	
	
	array_quotation = [];
	
	if (array_quotation.length == 0) {

		var len = results.rows.length;
   	
		for (var i=0; i< len; i++) {  

			current_notification.array_quotation = array_quotation[i];
			array_quotation[i] = results.rows.item(i);
		}
		
		ClearConfirmQuotation();
		BuildConfirmQuotationTable(array_quotation);
   }
	
	
}


function ClearPartList_NewQuotation() {
	

	$("#" + TAB_PARTS_QUOTATION_TABLE + " tr").remove();
	
	
	
	
	 
	

}

function BuildPartList_NewQuotation(array_parts){
	
	
	var thstr = '';
	thstr = thstr +"<tr>";
	thstr = thstr +"<th id='Tab_Quotation_Table_Column_No'>No</th>";
	thstr = thstr +"<th id='Tab_Quotation_Table_Column_ItemDesc'>Item/Material Desc</th>";
	thstr = thstr +"<th id='Tab_Quotation_Table_Column_PartNo'>Part No</th>";
	thstr = thstr +"<th id='Tab_Quotation_Table_Column_Qty'>Qty</th>";
	thstr = thstr +"<th id='Tab_Quotation_Table_Column_UPrice'>U.Price</th>";
	thstr = thstr +"<th id='Tab_Quotation_Table_Column_D'>D.(%)</th>";
	thstr = thstr +"<th id='Tab_Quotation_Table_Column_TotalPrice'>Total Price</th>";
	thstr = thstr +"</tr>";


	$("#" + TAB_PARTS_QUOTATION_TABLE + " thead:last").append(thstr);
	
	
	var str = "";
	
	
	for (var x = 0; x < array_parts.length; x++) {
	    
	    str = str + "<tr id='" + array_parts[x].internal_id + "'>";
	    
	    str = str + "<td>" + (x + 1) + "</td>";
	    str = str + "<td><input class='m-wrap small' type='text' value='"+ array_parts[x].part_material_desc +"' list='comicstitle' onkeypress='getcode(this.value);' /> </td>";
	    str = str + "<td><input class='m-wrap small' type='text' value='"+ array_parts[x].part_material +"' /> </td>";
	    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 1) +")' class='m-wrap small' type='text' value='"+ array_parts[x].part_quantity +"' /> </td>";
	    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 1) +")' class='m-wrap small' type='text' value='0' /> </td>";
	    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 1) +")' class='m-wrap small' type='text' value='0' /> </td>";
	    str = str + "<td>0</td>";
	    str = str + "</tr>";
	    if( x == 0) {
	    	$("#" + TAB_PARTS_QUOTATION_TABLE + " tbody:last").append(str);
	    	
	    } else {
	    	$("#" + TAB_PARTS_QUOTATION_TABLE + " tr:last").after(str);	    	
	    }
	    
	    str = "";
	    
	   // $("#" + TAB_PARTS_QUOTATION_TABLE + " tbody tr").remove();
	    
	}
	
	
	
	var TempDate = new Date();
	var month = TempDate.getMonth() + 1;
	var day = TempDate.getDate();
	var year = TempDate.getFullYear();
	h = TempDate.getHours();
	m = TempDate.getMinutes();
	s = TempDate.getSeconds();
	
	/// insert row Labor
	var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
	var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s + "1"); 
	var msg_encrypt = hex_md5 (msg_source);	
		
	str = str + "<tr id='" + msg_encrypt + "'>";
    str = str + "<td>" + (x + 1) + "</td>";
    str = str + "<td><input class='m-wrap small' type='text' value='Labor' list='comicstitle' onkeypress='getcode(this.value);' /> </td>";
    //str = str + "<td>Labor</td>";
    str = str + "<td><input class='m-wrap small' type='text' /></td>";
    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 1) +")' class='m-wrap small' type='text' value='1' /> </td>";
    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 1) +")' class='m-wrap small' type='text' value='0' /> </td>";
    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 1) +")' class='m-wrap small' type='text' value='0' /> </td>";
    str = str + "<td>0</td>";
    str = str + "</tr>";
    $("#" + TAB_PARTS_QUOTATION_TABLE + " tbody:last").append(str);
    str = "";
   

    /// insert row Transport
    msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s + "2"); 
	msg_encrypt = hex_md5 (msg_source);		
	str = str + "<tr id='" + msg_encrypt + "'>";
    str = str + "<td>" + (x + 2) + "</td>";
    str = str + "<td><input class='m-wrap small' type='text' value='Transport' list='comicstitle' onkeypress='getcode(this.value);' /> </td>";
    //str = str + "<td>Transport</td>";
    str = str + "<td><input class='m-wrap small' type='text'  />";
    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 2) +")' class='m-wrap small' type='text' value='1' /> </td>";
    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 2) +")' class='m-wrap small' type='text' value='0' /> </td>";
    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 2) +")' class='m-wrap small' type='text' value='0' /> </td>";
    str = str + "<td>0</td>";
    
    str = str + "</tr>";
    $("#" + TAB_PARTS_QUOTATION_TABLE + " tbody:last").append(str);
    str = "";
        

    /// insert row extra 1
    msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s + "3"); 
	msg_encrypt = hex_md5 (msg_source);		
	str = str + "<tr id='" + msg_encrypt + "'>";
    str = str + "<td>" + (x + 3) + "</td>";
    str = str + "<td><input class='m-wrap small' type='text' list='comicstitle' onkeypress='getcode(this.value);' /></td>";
    str = str + "<td><input class='m-wrap small' type='text' /></td>";
    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 3) +")' class='m-wrap small' type='text' />    </td>";
    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 3) +")' class='m-wrap small' type='text' /> </td>";
    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 3) +")' class='m-wrap small' type='text' /> </td>";
    str = str + "<td>0</td>";
    
    str = str + "</tr>";
    $("#" + TAB_PARTS_QUOTATION_TABLE + " tbody:last").append(str);
    str = "";
        

    /// insert row extra 2
    msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s + "4"); 
	msg_encrypt = hex_md5 (msg_source);		
	str = str + "<tr id='" + msg_encrypt + "'>";
    str = str + "<td>" + (x + 4) + "</td>";
    str = str + "<td><input class='m-wrap small' type='text' list='comicstitle' onkeypress='getcode(this.value);' /></td>";
    str = str + "<td><input class='m-wrap small' type='text' /></td>";
    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 4) +")' class='m-wrap small' type='text' /> </td>";
    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 4) +")' class='m-wrap small' type='text' /> </td>";
    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 4) +")' class='m-wrap small' type='text' /> </td>";
    str = str + "<td>0</td>";
    
    str = str + "</tr>";
    $("#" + TAB_PARTS_QUOTATION_TABLE + " tbody:last").append(str);
    str = "";

    /// insert row extra 3
    msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s + "5"); 
	msg_encrypt = hex_md5 (msg_source);		
	str = str + "<tr id='" + msg_encrypt + "'>";
    str = str + "<td>" + (x + 5) + "</td>";
    str = str + "<td><input class='m-wrap small' type='text' list='comicstitle' onkeypress='getcode(this.value);' /></td>";
    str = str + "<td><input class='m-wrap small' type='text' /></td>";
    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 5) +")' class='m-wrap small' type='text' /> </td>";
    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 5) +")' class='m-wrap small' type='text' /> </td>";
    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 5) +")' class='m-wrap small' type='text' /> </td>";
    str = str + "<td>0</td>";
    
    str = str + "</tr>";
    $("#" + TAB_PARTS_QUOTATION_TABLE + " tbody:last").append(str);
    str = "";
       
    $("table#" + TAB_PARTS_QUOTATION_TABLE + " tr#0").remove();
    
    
    if(countofaddquote==0)
	 {
    	countofaddquote = 1;   	
	 }
    else
    	{
    		oTable.fnClearTable(); 
    	}
   
 // $("#TAB_PARTS_QUOTATION_TABLE").find(":gt(0)").remove();
	 var oTable = $('#Tab_Parts_Quotation_Table').dataTable({
	    	'bDestroy': true,
	        "aLengthMenu": [
	            [5, 15, 20, -1],
	            [5, 15, 20, "All"] // change per page values here
	        ],
	        // set the initial value
	        "iDisplayLength": 5,
	        "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span6'i><'span6'p>>",
	       "sPaginationType": "bootstrap",
	        "oLanguage": {
	            "sLengthMenu": "_MENU_ records per page",
	            "oPaginate": {
	               "sPrevious": "Prev",
	               "sNext": "Next"
	           }
	      },
	        "aoColumnDefs": [{
	               'bSortable': false,
	               'aTargets': [0]
	           }
	       ]
	        
	   });
	 
	 
   


}

function QtyOnChange(ChangedQty, row_no) {

	row_no =  row_no - 1; 
	
	var Quantity =  $("#" + TAB_PARTS_QUOTATION_TABLE + " tr:gt("+ row_no +")").find('td').eq(3).find('input').val();
	var UPrice = $("#" + TAB_PARTS_QUOTATION_TABLE + " tr:gt("+ row_no +")").find('td').eq(4).find('input').val()
	var DiscountInput = $("#" + TAB_PARTS_QUOTATION_TABLE + " tr:gt("+ row_no +")").find('td').eq(5).find('input').val()

	if ( isNaN(Quantity)== false && isNaN(UPrice)== false && isNaN(DiscountInput)== false ) {
	    if(Quantity.length > 0 && UPrice.length > 0 && DiscountInput.length > 0 ) {
	    	 
	    	var Total_Price = parseFloat ( parseFloat(Quantity) * parseFloat(UPrice) * (( 100 - parseInt(DiscountInput) ) / 100 ) ).toFixed(2) ;
			$("#" + TAB_PARTS_QUOTATION_TABLE + " tr:gt("+ row_no +")").find('td').eq(6).text(Total_Price);
	    } else {
	    	$("#" + TAB_PARTS_QUOTATION_TABLE + " tr:gt("+ row_no +")").find('td').eq(6).text("0");
	    }
	    
		
	} else {
		alert("Input value must in numeric");
		$("#" + TAB_PARTS_QUOTATION_TABLE + " tr:gt("+ row_no +")").find('td').eq(6).text("0");
	}
	
	
	
}

function EditQtyOnChange(ChangedQty, row_no) {

	row_no =  row_no ; 
	
	var Quantity =  $("#Tab_Parts_Quotation_Table_Edit tr:gt("+ row_no +")").find('td').eq(3).find('input').val();
	var UPrice = $("#Tab_Parts_Quotation_Table_Edit tr:gt("+ row_no +")").find('td').eq(4).find('input').val()
	var DiscountInput = $("#Tab_Parts_Quotation_Table_Edit tr:gt("+ row_no +")").find('td').eq(5).find('input').val()

	if ( isNaN(Quantity)== false && isNaN(UPrice)== false && isNaN(DiscountInput)== false ) {
	    if(Quantity.length > 0 && UPrice.length > 0 && DiscountInput.length > 0 ) {
	    	 
	    	var Total_Price = parseFloat ( parseFloat(Quantity) * parseFloat(UPrice) * (( 100 - parseInt(DiscountInput) ) / 100 ) ).toFixed(2) ;
			$("#Tab_Parts_Quotation_Table_Edit tr:gt("+ row_no +")").find('td').eq(6).text(Total_Price);
	    } else {
	    	$("#Tab_Parts_Quotation_Table_Edit tr:gt("+ row_no +")").find('td').eq(6).text("0");
	    }
	    
		
	} else {
		alert("Input value must in numeric");
		$("#Tab_Parts_Quotation_Table_Edit tr:gt("+ row_no +")").find('td').eq(6).text("0");
	}
	
	
	
}


function ClearConfirmQuotation(){
	
	$("#" + TAB_QUOTATION_TABLE + " tr:gt(0)").remove();
	
}


function BuildConfirmQuotationTable(array_quotation){

	var str = "";

	for (var x = 0; x < array_quotation.length; x++) {
	    
	    str = str + "<tr id='" + array_quotation[x].internal_id + "'>";
	    str = str + "<td>" + array_quotation[x].internal_id + "</td>";
	    str = str + "<td>" + array_quotation[x].quotation_notice + "</td>";
	    str = str +  "<td><a onclick=\"return EditQuotation('" + array_quotation[x].internal_id + "');\" href='#modal_edit_quotation' data-toggle='modal' >Edit</a></td>";
	    
	    str = str + "</tr>";
	    $("#" + TAB_QUOTATION_TABLE + " tr:last").after(str);
	    str = "";
	    
	}
	
	//App.init();
    //FormSamples.init();
    //FormWizard.init();
    //TableEditable.init();
    //UITree.init();
    //TableManaged.init();

    LoadSummaryTab();

}

function EditQuotation(QuotationHeaderID) {
	
	SelectedQuotationHeaderID = QuotationHeaderID;
	
	db.transaction(function(tx) {
		tx.executeSql("SELECT * FROM op_quotation WHERE internal_id = '" + SelectedQuotationHeaderID + "' ;", [], LoadQuotationHeader, errorCB);
	});

}

function LoadQuotationHeader(tx, results){

	if ( results.rows.length > 0 ) {
		
		current_notification.quotation = new obj_quotation_header(SelectedQuotationHeaderID);
		current_notification.quotation.quotation_notification = results.rows.item(0).quotation_notification;
		current_notification.quotation.quotation_no = results.rows.item(0).quotation_no;
		current_notification.quotation.quotation_notice = results.rows.item(0).quotation_notice;
		current_notification.quotation.quotation_userstatus = results.rows.item(0).quotation_userstatus;
		current_notification.quotation.quotation_validfrom = results.rows.item(0).quotation_validfrom;
		current_notification.quotation.quotation_validto = results.rows.item(0).quotation_validto;
		current_notification.quotation.quotation_engineer = results.rows.item(0).quotation_engineer;
		current_notification.quotation.quotation_status = results.rows.item(0).quotation_status;
		current_notification.quotation.quotation_currency = results.rows.item(0).quotation_currency;
		current_notification.quotation.quotation_incoterm1 = results.rows.item(0).quotation_incoterm1;
		current_notification.quotation.quotation_incoterm2 = results.rows.item(0).quotation_incoterm2;
		current_notification.quotation.quotation_paymentterm = results.rows.item(0).quotation_paymentterm;
		current_notification.quotation.quotation_deliveryterm = results.rows.item(0).quotation_deliveryterm;
		current_notification.quotation.quotation_attn = results.rows.item(0).quotation_attn;
		current_notification.quotation.quotation_fax_email = results.rows.item(0).quotation_fax_email;
		current_notification.quotation.quotation_date = results.rows.item(0).quotation_date;
		current_notification.quotation.quotation_customer_name = results.rows.item(0).quotation_customer_name;
		current_notification.quotation.quotation_customer_address = results.rows.item(0).quotation_customer_address;
		current_notification.quotation.quotation_validity = results.rows.item(0).quotation_validity;
		current_notification.quotation.quotation_isdownloaded = results.rows.item(0).quotation_isdownloaded;

		$("#txt_quotation_remarks_edit").val(results.rows.item(0).quotation_notice);
		$("#txt_AttnTo_edit").val(results.rows.item(0).quotation_attn);
		$("#txt_FaxEmail_edit").val(results.rows.item(0).quotation_fax_email);

		//load dropdown Validity Period:	
		$('#Dropdown_ValidityPeriod_edit option').each(function(){
			var option = this.value
			if(option == results.rows.item(0).quotation_validity){
				$(this).attr('selected', 'selected');
			}
		});

		//load dropdown Term of Payment:
		$('#Dropdown_QuotationPayment_edit option').each(function(){
			var option = this.value
			if(option == results.rows.item(0).quotation_paymentterm){
				$(this).attr('selected', 'selected');
			}
		});
		
		if(current_notification.quotation.quotation_isdownloaded == "1"){
			$("#Button_Update_Quotation").hide();
		} else {
			$("#Button_Update_Quotation").show();
		}
		
		
    }
    
	db.transaction(function(tx) {
		tx.executeSql("SELECT * FROM op_quotation_detail WHERE detail_quotation = '" + results.rows.item(0).internal_id + "' ;", [], LoadQuotationDetailTable, errorCB);
	});

}

function LoadQuotationDetailTable(tx, results){
	
	SelectedQuotationTotalPrice = "0.00";
	$('#Tab_Parts_Quotation_Table_Edit').dataTable().fnClearTable();

	if ( results.rows.length > 0 ) {

		var str = "";
		for (var x = 0; x < results.rows.length; x++) {
		    
		    str = str + "<tr id='" + results.rows.item(x).internal_id + "'>";
		    str = str + "<td>" + (x + 1) + "</td>";
		    str = str + "<td><input class='m-wrap small' type='text' value='"+ results.rows.item(x).detail_description +"' list='comicstitle' onkeypress='getcode(this.value);'  /> </td>";
		    str = str + "<td><input class='m-wrap small' type='text' value='"+ results.rows.item(x).detail_partno +"' /> </td>";
		    str = str + "<td><input onchange='EditQtyOnChange(this, "+ x +")' class='m-wrap small' type='text' value='"+ results.rows.item(x).detail_quantity +"' /> </td>";
		    str = str + "<td><input onchange='EditQtyOnChange(this, "+ x +")' class='m-wrap small' type='text' value='"+ results.rows.item(x).detail_rate +"' /> </td>";
		    str = str + "<td><input onchange='EditQtyOnChange(this, "+ x +")' class='m-wrap small' type='text' value='"+ results.rows.item(x).detail_discount +"' /> </td>";
		    str = str + "<td>"+ results.rows.item(x).detail_total_price +"</td>";
		    str = str + "</tr>";
		    if(x == 0) {
		    	$("#Tab_Parts_Quotation_Table_Edit tbody:last").append(str);
		    } else {
		    	$("#Tab_Parts_Quotation_Table_Edit tr:last").after(str);
		    }
		    
		    SelectedQuotationTotalPrice =  parseFloat(SelectedQuotationTotalPrice) + parseFloat(results.rows.item(x).detail_total_price);
		    
		   
		    str = "";
		    
		}
		$("#Tab_Quotation_TotalPrice").val(SelectedQuotationTotalPrice.toFixed(2));

		var TempDate = new Date();
		var month = TempDate.getMonth() + 1;
		var day = TempDate.getDate();
		var year = TempDate.getFullYear();
		h = TempDate.getHours();
		m = TempDate.getMinutes();
		s = TempDate.getSeconds();

		var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
		var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s + "1"); 
		var msg_encrypt = hex_md5 (msg_source);		
		
		str = str + "<tr id='" + msg_encrypt + "'>";
	    str = str + "<td>" + (x + 1) + "</td>";
	    str = str + "<td><input class='m-wrap small' type='text' list='comicstitle' onkeypress='getcode(this.value);' /></td>";
	    str = str + "<td><input class='m-wrap small' type='text' /></td>";
	    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 1) +")' class='m-wrap small' type='text' /> </td>";
	    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 1) +")' class='m-wrap small' type='text' /> </td>";
	    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 1) +")' class='m-wrap small' type='text' /> </td>";
	    str = str + "<td>0</td>";
	    
	    str = str + "</tr>";
	    $("#Tab_Parts_Quotation_Table_Edit tbody:last").append(str);
	    str = "";
	  

	    /// insert row extra 2
	    msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s + "2"); 
		msg_encrypt = hex_md5 (msg_source);		
		str = str + "<tr id='" + msg_encrypt + "'>";
	    str = str + "<td>" + (x + 2) + "</td>";
	    str = str + "<td><input class='m-wrap small' type='text' list='comicstitle' onkeypress='getcode(this.value);' /></td>";
	    str = str + "<td><input class='m-wrap small' type='text' /></td>";
	    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 2) +")' class='m-wrap small' type='text' /> </td>";
	    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 2) +")' class='m-wrap small' type='text' /> </td>";
	    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 2) +")' class='m-wrap small' type='text' /> </td>";
	    str = str + "<td>0</td>";
	    
	    str = str + "</tr>";
	    $("#Tab_Parts_Quotation_Table_Edit tbody:last").append(str);
	    str = "";

	    /// insert row extra 3
	    msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s + "3"); 
		msg_encrypt = hex_md5 (msg_source);		
		str = str + "<tr id='" + msg_encrypt + "'>";
	    str = str + "<td>" + (x + 3) + "</td>";
	    str = str + "<td><input class='m-wrap small' type='text' list='comicstitle' onkeypress='getcode(this.value);' /></td>";
	    str = str + "<td><input class='m-wrap small' type='text' /></td>";
	    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 3) +")' class='m-wrap small' type='text' /> </td>";
	    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 3) +")' class='m-wrap small' type='text' /> </td>";
	    str = str + "<td><input onchange='QtyOnChange(this, "+ (x + 3) +")' class='m-wrap small' type='text' /> </td>";
	    str = str + "<td>0</td>";
	    
	    str = str + "</tr>";
	    $("#Tab_Parts_Quotation_Table_Edit tbody:last").append(str);
	    str = "";
	    
	    
		$("table#Tab_Parts_Quotation_Table_Edit tr#0").remove();
	    
		var oTable = $('#Tab_Parts_Quotation_Table_Edit').dataTable({
			'bDestroy': true,
	        "aLengthMenu": [
	            [5, 15, 20, -1],
	            [5, 15, 20, "All"] // change per page values here
	        ],
	        // set the initial value
	        "iDisplayLength": 5,
	        "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span6'i><'span6'p>>",
	       "sPaginationType": "bootstrap",
	        "oLanguage": {
	            "sLengthMenu": "_MENU_ records per page",
	            "oPaginate": {
	               "sPrevious": "Prev",
	               "sNext": "Next"
	           }
	      },
	        "aoColumnDefs": [{
	               'bSortable': false,
	               'aTargets': [0]
	           }
	       ]
	        
	   });
		
		$("table#Tab_Parts_Quotation_Table_Edit").css("width","100%");
		
		
	}
	
}


//********************************************************************************************************************
//*** BEGIN Summary Tab
function LoadSummaryTab(){



	var str = "";
	
	
	var total_travel_time  = 0.00;
	var total_working_time = 0.00;


	$("#Tab_Summary_NotificationID").text(current_notification.notification_id);
	$("#Tab_Summary_NotificationID_Header").text(current_notification.notification_id);
	$("#Tab_Summary_Notification_Title").text(current_notification.title);
	$("#Tab_Summary_Act_Type").text(current_notification.activity.master_desc);
	$("#Tab_Summary_Sold_To").text(current_notification.customer.cust_name1);
	
	
	
	
	$("#List_Summary_Damages").empty();
	
	
	if (array_damages.length > 0) {

		for (var i=0; i< array_damages.length; i++) {  

			str = str + "<li><a href='#' data-role='leaf'><i class='icon-wrench'></i>"+ array_damages[i].damage_group_desc + " : " + array_damages[i].damage_code_desc + "</a></li>";
		    $("#List_Summary_Damages").append(str);

		    str = "";
		} 
	}
	
	
	$("#List_Summary_Causes").empty();
	
	if (array_causes.length > 0) {

		for (var i=0; i< array_causes.length; i++) {  

			str = str + "<li><a href='#' data-role='leaf'><i class='icon-wrench'></i>"+ array_causes[i].cause_group_desc + " : " + array_causes[i].cause_code_desc + "</a></li>";
		    $("#List_Summary_Causes").append(str);

		    str = "";
		} 
	}

	
	if (array_timeline.length > 0) { 
		
		for (var j=0; j< array_timeline.length; j++) { 
			
			total_travel_time = total_travel_time +  parseFloat(array_timeline[j].job_travel); 
			
			var workingstart = new Date(array_timeline[j].job_start) , workingend = new Date(array_timeline[j].job_end), diff  = new Date(workingend - workingstart), job_working_count  = diff/1000/60/60;
			total_working_time = total_working_time + parseFloat(job_working_count.toFixed(2));
			
		}  	
		
		
		var a = total_travel_time.toString();
		var travel_hour =  a.substr(0, a.indexOf('.'));
		var travel_minutes = a.substr(a.indexOf(".") + 1) ;
		travel_minutes = ( travel_minutes /100 ) * 60 ;
		$("#Tab_Summary_TotalTravelTime").text(travel_hour + " Hours " + parseInt(travel_minutes) + " Minutes");	


		var b = total_working_time.toString();
		var working_hour =  b.substr(0, b.indexOf('.'));
		var working_minutes = b.substr(b.indexOf(".") + 1) ;
		working_minutes = ( working_minutes /100 ) * 60 ;
		$("#Tab_Summary_TotalWorkingTime").text(working_hour + " Hours " + parseInt(working_minutes) + " Minutes");	


		var total_overall_time = 0.00;
		total_overall_time = (total_travel_time + total_working_time).toFixed(2);
		var c = total_overall_time.toString();
		var overall_hour =  c.substr(0, c.indexOf('.'));
		var overall_minutes = c.substr(c.indexOf(".") + 1) ;
		overall_minutes = ( overall_minutes /100 ) * 60 ;
		$("#Tab_Summary_TotalOverallTime").text(overall_hour + " Hours " + parseInt(overall_minutes) + " Minutes");	

		
	}


	$("#List_Summary_Parts").empty();
	if (current_part.length > 0) {

		for (var j=0; j< current_part.length; j++) {  

			var material = ""; 
			if(current_part[j].part_material == null) {
				material = "";
			} else {
				material = current_part[j].part_material; 
			}
			str = str + "<li><a href='#' data-role='leaf'><i class='icon-wrench'></i>"+ material + " : " + current_part[j].part_material_desc + " : "  + current_part[j].part_quantity  + "</a></li>";
		    $("#List_Summary_Parts").append(str);

		    str = "";
		} 
	}

	$("#List_Summary_Timeline").empty();
	if (array_timeline.length > 0) { 
		for (var j=0; j< array_timeline.length; j++) { 
		
			var a = array_timeline[j].job_travel.toString();
			var travel_hour =  a.substr(0, a.indexOf('.'));
			var travel_minutes = a.substr(a.indexOf(".") + 1) ;
			travel_minutes = ( travel_minutes /100 ) * 60 ;
			
			
			str = str + "<li><a href='#' class='tree-toggle closed' data-role='tree-toggle' data-toggle='branch' data-value='Bootstrap_Tree'> Job Date : " + array_timeline[j].job_date + "</a>";
			str = str + "<ul class='branch'>";
			str = str + "<li><i class='icon-arrow-right'></i>Description : "+ array_timeline[j].job_description +" </li>";
			str = str + "<li><i class='icon-arrow-right'></i>Travel Start : "+ array_timeline[j].job_travel_start +" </li>";
			str = str + "<li><i class='icon-arrow-right'></i>Travel End : " + array_timeline[j].job_travel_end + " </li>";
			str = str + "<li><i class='icon-arrow-right'></i>Total Travel Time : " + travel_hour + " Hours " + parseInt(travel_minutes) + " Minutes" + " </li>";
			str = str + "<li><i class='icon-arrow-right'></i>Waiting : " + array_timeline[j].job_waiting + "</li>";
			str = str + "<li><i class='icon-arrow-right'></i>Job Start : " + array_timeline[j].job_start + " </li>";
			str = str + "</ul>";
			str = str + "</li>";
			$("#List_Summary_Timeline").append(str);

		    str = "";
		    
		}
	}
	
	

	
	LoadSurveySignOff();
	
	
	
}

function ReLoadSummaryTab(){

	var str = "";
	
	
	var total_travel_time  = 0.00;
	var total_working_time = 0.00;


	$("#Tab_Summary_NotificationID").text(current_notification.notification_id);
	$("#Tab_Summary_NotificationID_Header").text(current_notification.notification_id);
	$("#Tab_Summary_Notification_Title").text(current_notification.title);
	$("#Tab_Summary_Act_Type").text(current_notification.activity.master_desc);
	$("#Tab_Summary_Sold_To").text(current_notification.customer.cust_name1);
	
	
	
	
	$("#List_Summary_Damages").empty();
	
	
	if (array_damages.length > 0) {

		for (var i=0; i< array_damages.length; i++) {  

			str = str + "<li><a href='#' data-role='leaf'><i class='icon-wrench'></i>"+ array_damages[i].damage_group_desc + " : " + array_damages[i].damage_code_desc + "</a></li>";
		    $("#List_Summary_Damages").append(str);

		    str = "";
		} 
	}
	
	
	$("#List_Summary_Causes").empty();
	
	if (array_causes.length > 0) {

		for (var i=0; i< array_causes.length; i++) {  

			str = str + "<li><a href='#' data-role='leaf'><i class='icon-wrench'></i>"+ array_causes[i].cause_group_desc + " : " + array_causes[i].cause_code_desc + "</a></li>";
		    $("#List_Summary_Causes").append(str);

		    str = "";
		} 
	}

	
	if (array_timeline.length > 0) { 
		
		for (var j=0; j< array_timeline.length; j++) { 
			
			total_travel_time = total_travel_time +  parseFloat(array_timeline[j].job_travel); 
			
			var workingstart = new Date(array_timeline[j].job_start) , workingend = new Date(array_timeline[j].job_end), diff  = new Date(workingend - workingstart), job_working_count  = diff/1000/60/60;
			total_working_time = total_working_time + parseFloat(job_working_count.toFixed(2));
			
		}  	
		
		
		var a = total_travel_time.toString();
		var travel_hour =  a.substr(0, a.indexOf('.'));
		var travel_minutes = a.substr(a.indexOf(".") + 1) ;
		travel_minutes = ( travel_minutes /100 ) * 60 ;
		$("#Tab_Summary_TotalTravelTime").text(travel_hour + " Hours " + parseInt(travel_minutes) + " Minutes");	


		var b = total_working_time.toString();
		var working_hour =  b.substr(0, b.indexOf('.'));
		var working_minutes = b.substr(b.indexOf(".") + 1) ;
		working_minutes = ( working_minutes /100 ) * 60 ;
		$("#Tab_Summary_TotalWorkingTime").text(working_hour + " Hours " + parseInt(working_minutes) + " Minutes");	


		var total_overall_time = 0.00;
		total_overall_time = (total_travel_time + total_working_time).toFixed(2);
		var c = total_overall_time.toString();
		var overall_hour =  c.substr(0, c.indexOf('.'));
		var overall_minutes = c.substr(c.indexOf(".") + 1) ;
		overall_minutes = ( overall_minutes /100 ) * 60 ;
		$("#Tab_Summary_TotalOverallTime").text(overall_hour + " Hours " + parseInt(overall_minutes) + " Minutes");	

		
	}


	$("#List_Summary_Parts").empty();
	if (current_part.length > 0) {

		for (var j=0; j< current_part.length; j++) {  

			var material = ""; 
			if(current_part[j].part_material == null) {
				material = "";
			} else {
				material = current_part[j].part_material; 
			}
			str = str + "<li><a href='#' data-role='leaf'><i class='icon-wrench'></i>"+ material + " : " + current_part[j].part_material_desc + " : "  + current_part[j].part_quantity  + "</a></li>";
		    $("#List_Summary_Parts").append(str);

		    str = "";
		} 
	}

	$("#List_Summary_Timeline").empty();
	if (array_timeline.length > 0) { 
		for (var j=0; j< array_timeline.length; j++) { 
		
			var a = array_timeline[j].job_travel.toString();
			var travel_hour =  a.substr(0, a.indexOf('.'));
			var travel_minutes = a.substr(a.indexOf(".") + 1) ;
			travel_minutes = ( travel_minutes /100 ) * 60 ;
			
			
			str = str + "<li><a href='#' class='tree-toggle closed' data-role='tree-toggle' data-toggle='branch' data-value='Bootstrap_Tree'> Job Date : " + array_timeline[j].job_date + "</a>";
			str = str + "<ul class='branch'>";
			str = str + "<li><i class='icon-arrow-right'></i>Description : "+ array_timeline[j].job_description +" </li>";
			str = str + "<li><i class='icon-arrow-right'></i>Travel Start : "+ array_timeline[j].job_travel_start +" </li>";
			str = str + "<li><i class='icon-arrow-right'></i>Travel End : " + array_timeline[j].job_travel_end + " </li>";
			str = str + "<li><i class='icon-arrow-right'></i>Total Travel Time : " + travel_hour + " Hours " + parseInt(travel_minutes) + " Minutes" + " </li>";
			str = str + "<li><i class='icon-arrow-right'></i>Waiting : " + array_timeline[j].job_waiting + "</li>";
			str = str + "<li><i class='icon-arrow-right'></i>Job Start : " + array_timeline[j].job_start + " </li>";
			str = str + "</ul>";
			str = str + "</li>";
			$("#List_Summary_Timeline").append(str);

		    str = "";
		    
		}
	}
		
	
	
}

//********************************************************************************************************************
//*** BEGIN Final Tab

function LoadFinalTab() {
	
	
	
	var str = "";
	
	$("#Tab_Invoice_notification_no").text(current_notification.internal_id);
	$("#Tab_Invoice_so").text(current_notification.so);
	$("#Tab_Invoice_Customer").text(current_notification.customer.cust_name1 + current_notification.customer.cust_name2);
	$("#Tab_Invoice_Address").text(current_notification.customer.cust_street + current_notification.customer.cust_city + current_notification.customer.cust_po);
	$("#Tab_Invoice_Tel").text(current_notification.customer.cust_tel1);
	$("#Tab_Invoice_ActType").text(current_notification.activity.master_desc);
	
	if (array_damages.length > 0) {
		var FaultDesc = "";
		for (var i=0; i< array_damages.length; i++) {  

			FaultDesc = array_damages[i].damage_code_desc;
			
		} 
		
		$("#Tab_Invoice_FaultDesc").text(FaultDesc);
	}
	
	if (array_causes.length > 0) {
		var FaultCause = "";
		for (var i=0; i< array_causes.length; i++) {  
			
		    FaultCause = array_causes[i].cause_code_desc;
		    
		} 
		$("#Tab_Invoice_FaultCause").text(FaultCause);
	}

	
	
	$("#Tab_Invoice_JobStatus").text(current_notification.statusdesc);
	$("#Tab_Invoice_Subject").text(current_notification.title);
	$("#Tab_Invoice_ModelNo").text(current_notification.equipment.equipmentid);
	$("#Tab_Invoice_SN").text(current_notification.equipment.equipment_snr);
	$("#Tab_Invoice_Location").text(current_notification.equipment.equipment_location);
	$("#Tab_Invoice_fax_email").text(current_notification.customer.cust_fax);


	if(current_notification.status == "E0009") { 
		 $("#btn_job_finish").hide();  
	} 
	
	if(TimelineStarted) {
		 $("#btn_job_finish").hide();
	} 
	
	$("#Tab_Invoice_Timeline_Table tr:gt(0)").remove();
	
	if (array_timeline.length > 0) { 
		
		for (var i=0; i< array_timeline.length; i++) {  

			str = "<tr id='" + array_timeline[i].internal_id  + "'>";
			str += "<td>" + (i+1) + "</td>";
			str += "<td>" + array_timeline[i].job_start + "</td>";
			str += "<td>" + array_timeline[i].job_description + "</td>";
			str += "</tr>";
			
			if(i == 0) {
				$("#Tab_Invoice_Timeline_Table > tbody:last").append(str);
			} else {
				$("#Tab_Invoice_Timeline_Table tr:last").after(str);
			}
			
		    str = "";
		} 
		
	}
	
	$("#Tab_Invoice_Parts_Table tr:gt(0)").remove();
	if (current_part.length > 0) {

		var k = 0;
		
		for (var j=0; j< current_part.length; j++) {  
			if(parseInt(current_part[j].part_consumed) > 0) {
				str = "<tr id='" + current_part[j].internal_id  + "'>";
				str += "<td>" + (k+1) + "</td>";
				str += "<td>" + current_part[j].part_material_desc + "</td>";
				str += "<td>" + current_part[j].part_consumed + "</td>";
				str += "<td>" + current_part[j].part_unit + "</td>";
				str += "</tr>";
				
				if(j == 0) {
					$("#Tab_Invoice_Parts_Table > tbody:last").append(str);
				} else {
					$("#Tab_Invoice_Parts_Table tr:last").after(str);
				}
				
				k= k+1;
			    str = "";
			}
		    
		    
		} 
	}
	
	
	if (array_timeline.length > 0) { 
		var count = array_timeline.length-1;
		for (var k=0; k< array_timeline.length; k++) {
			
			if(array_timeline[k].job_start !== undefined) {

				
				$("#Tab_Invoice_Travelling_Time").text(array_timeline[count].job_travel);
				$("#Tab_Invoice_Waiting_Time").text(array_timeline[count].job_waiting);
				$("#Tab_Invoice_Work_Start").text(array_timeline[count].job_start);
				$("#Tab_Invoice_Work_End").text(array_timeline[count].job_end);
			}

			//return false;
		}
		
	}
	
	$("#Tab_Invoice_Engineer").text(current_login.user_firstname);
	
	//LoadTravelback();
	
	
	
}


function LoadTravelback() {
	
	db.transaction(function(tx) {
		tx.executeSql("select * from op_travelback where notification_id = '"+ current_notification.internal_id +"' ;", [], "",  errorCB);
	}); 
}

//********************************************************************************************************************
//*** BEGIN Survey / Sign Off  Tab
function LoadSurveySignOff() {
	
	db.transaction(function(tx) {
		tx.executeSql("select * from op_survey where survey_notification = '"+ current_notification.internal_id +"' ;", [], LoadSurveySignOff_querySuccess,  errorCB);
	}); 
	
}

function LoadSurveySignOff_querySuccess(tx, results) {

	var len = results.rows.length;

	if(len > 0){
		
		current_notification.survey = new obj_survay(current_notification.internal_id);
		current_notification.survey.internal_id = results.rows.item(0).internal_id;
		current_notification.survey.survey_notification = results.rows.item(0).survey_notification;
		current_notification.survey.survey_comments = results.rows.item(0).survey_comments;
		current_notification.survey.survey_date = results.rows.item(0).survey_date;
		current_notification.survey.survey_remarks = results.rows.item(0).survey_remarks;
		
		$("#Tab_Invoice_SurveyComment").text(current_notification.survey.survey_comments);
		$("#Tab_Invoice_SurveyRemarks").text(current_notification.survey.survey_remarks);
		
		$("#btn_survey").hide();
		
	}
	
	LoadSignOff(); 
	LoadFinalTab(); 
	
	//$('body').removeClass("loading");
	$.isLoading( "hide" );
	
}

function LoadSignOff() {
	
	db.transaction(function(tx) {
		tx.executeSql("select * from op_signature where notification_id = '"+ current_notification.internal_id +"' ;", [], LoadSignOff_querySuccess,  errorCB);
	}); 
	
}

function LoadSignOff_querySuccess(tx, results) {
	
	var len = results.rows.length;

	if(len > 0){
		
		current_notification.signature = new obj_signature(current_notification.internal_id);
		current_notification.signature.notification_id = results.rows.item(0).notification_id;
		current_notification.signature.notification_signature = results.rows.item(0).notification_signature;
		current_notification.signature.notification_signature_json = results.rows.item(0).notification_signature_json;
		current_notification.signature.signature_name = results.rows.item(0).signature_name;
		current_notification.signature.signature_contact = results.rows.item(0).signature_contact;
		current_notification.signature.signature_dept = results.rows.item(0).signature_dept;
		current_notification.signature.signature_designation = results.rows.item(0).signature_designation;

		$("#Tab_SignOff_Name").val(current_notification.signature.signature_name);
		$("#Tab_SignOff_Designation").val(current_notification.signature.signature_designation);
		$("#Tab_SignOff_Contact").val(current_notification.signature.signature_contact);
		$("#Tab_SignOff_Dept").val(current_notification.signature.signature_dept);
		$('.sigPad').signaturePad({displayOnly:true}).regenerate(current_notification.signature.notification_signature_json);
		
		// load base64 for approver signature in final tab 
		$("#tab_final_approvedby_img").attr('src', current_notification.signature.notification_signature); 
		$("#tab_final_approved_by").text(current_notification.signature.signature_name);
		$("#tab_final_designation").text(current_notification.signature.signature_designation);
		$("#tab_final_dept").text(current_notification.signature.signature_dept);
		
	} else {
		$('.sigPad').signaturePad({displayOnly:true}).regenerate("");
	}
	
}


function save_signature() {
	
	var smooth = false; 
	
	 var signdatajson = $('.sigPad').signaturePad().getSignatureString( );
	 var signdata = $('.sigPad').signaturePad().getSignatureImage( );
	 var signoffname = $("#Tab_SignOff_Name").val(); 
	 var signoffdesignation = $("#Tab_SignOff_Designation").val(); 
	 var signoffcontact = $("#Tab_SignOff_Contact").val(); 
	 var signoffdept = $("#Tab_SignOff_Dept").val(); 

	 ///delete existing data
	 
	 smooth = true;
	 
	 
	db.transaction(function(tx) {
			tx.executeSql("delete from op_signature where notification_id = '"+ current_notification.internal_id +"' ;", [], function(){smooth = true},  errorCB);
	}); 
		
	 if(smooth) {
		
		 db.transaction(function(tx) {
				tx.executeSql("insert into op_signature values " +
						" ('"+ current_notification.internal_id +"', '"+ signdata +"', '"+ signoffname +"', '"+ signoffcontact +"', '"+ signoffdept +"', '"+ signoffdesignation +"', '"+ signdatajson +"'  ) ;", [], function(){smooth = true},  errorCB);
		 }); 
		 
		 LoadSignOff();
		 
		 //$("#tab_final_approvedby_img").attr('src', signdata); 
		 //$("#tab_final_approved_by").text(signoffname);
		 //$("#tab_final_designation").text(signoffdesignation);
		 //$("#tab_final_dept").text(signoffdept);
		 
		 
		 alert("Acknowledgement Done"); 
			
	 }

}




function survey_save() {
	

	var TempDate = new Date();
	var month = TempDate.getMonth() + 1;
	var day = TempDate.getDate();
	var year = TempDate.getFullYear();
	h = TempDate.getHours();
	m = TempDate.getMinutes();
	s = TempDate.getSeconds();
	
	var rindex = Math.floor((Math.random()*12)+1) - 1;                                   
	var msg_source = PrepareKey(keys[rindex], current_login.user_id + day + month + year + h + m + s); 
	var msg_encrypt = hex_md5 (msg_source);		
	var a = msg_encrypt;
	var b = "-";
	var position1 = 8;
	var position2 = position1 + 4;
	var msg_encrypt_output = [a.slice(0, 8), b, a.slice(8,12), b, a.slice(12,16), b, a.slice(16,20), b, a.slice(20,32)].join('');

	var SurveyNotification = current_notification.internal_id;
	var SurveyRemarks = $("#Text_SurveyRemarks").val(); 
	
	var d = new Date(); 
	var month = ("0" + (d.getMonth() + 1)).slice(-2);
	var day = ("0" + d.getDate()).slice(-2);
	var year = d.getFullYear();	
	var h = d.getHours();
	var m = d.getMinutes();
	var SurveyDate =  year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;
	

	var SurveyComments = $('input[name=optionsSurvey]:checked').val();
	
	db.transaction(function(tx) {
		tx.executeSql("insert into op_survey values " +
				"('" + msg_encrypt_output + "' , '"+ SurveyNotification +"' , '"+ SurveyComments +"', '"+ SurveyDate +"', '"+ SurveyRemarks +"' );" , [], SurveyCompleted,  errorCB);
		});
	
}

function SurveyCompleted() {
	
	db.transaction(function(tx) {
		tx.executeSql("select * from op_survey where survey_notification = '"+ current_notification.internal_id +"' ;", [], ReloadFinalSurveyDetail,  errorCB);
	}); 
	
	 
	LoadFinalTab();

	document.getElementById('Button_Survey_Back').click();
	//document.getElementById('Tab_SurveySignOff_Button_Save').hide();
	
	$("#btn_survey").hide();
	
}

function ReloadFinalSurveyDetail(tx, results){
	
	var len = results.rows.length;

	if(len > 0){
		
		current_notification.survey = new obj_survay(current_notification.internal_id);
		current_notification.survey.internal_id = results.rows.item(0).internal_id;
		current_notification.survey.survey_notification = results.rows.item(0).survey_notification;
		current_notification.survey.survey_comments = results.rows.item(0).survey_comments;
		current_notification.survey.survey_date = results.rows.item(0).survey_date;
		current_notification.survey.survey_remarks = results.rows.item(0).survey_remarks;
		
		
		$("#Tab_Invoice_SurveyComment").text(results.rows.item(0).survey_comments);
		$("#Tab_Invoice_SurveyRemarks").text(results.rows.item(0).survey_remarks);
		
	}
	
	
}








function SyncNow() {

	//array_signature_upload[0] = new obj_signature("9bf5f2b4-5977-4689-b5fe-2d6c576ede8d");
	//array_signature_upload[0].notification_id = "9bf5f2b4-5977-4689-b5fe-2d6c576ede8d";
	//array_signature_upload[0].notification_signature = "XXXXXXX";
	//array_signature_upload[0].signature_name = "GEOKWIEW";
	//array_signature_upload[0].signature_contact = "999";
	//array_signature_upload[0].signature_dept = "IT";
	//array_signature_upload[0].signature_designation = "system analyst";
	 //$('#Tab_Detail_AccountType_Value').text( JSON.stringify(array_signature_upload)   );	
	
	
	//array_message[0] = new obj_message("677C79B5-636F-445B-928B-93F422C8430A");
	//array_message[0].internal_id = "677C79B5-636F-445B-928B-93F422C8430A";
	//array_message[0].engineer_id = "00022668";
	//array_message[0].msg_date = "2013-09-17 16:08:23.000";
	//array_message[0].msg_arrival_date = "2015-01-16 00:08:23.000";
	//array_message[0].msg_text = "xxxx";
	//array_message[0].msg_isread = "1";
	//$('#Tab_Detail_AccountType_Value').text(JSON.stringify(array_message));	
	//alert("array_message 2");
	
	if (confirm("Synchronize now?")) { 
		
		//console.log('Testing');
		 // do things if OK
		db.transaction(function(tx) {
			tx.executeSql("select * from op_notification where notification_requiredstart <= '"+ date_to +"' or notification_requiredstart like '"+ date_to +"%' and notification_sapready  = '1' and notification_resp = '"+ current_login.user_id +"';", [], SuccessLoadData, errorCB);
		});

	}
	
}

function SuccessLoadData(tx, results) {
	
	

	var len = results.rows.length;

	if(len > 0) {
		
		for (var i=0; i< len; i++) {  


			current_notification = new obj_notification(results.rows.item(i).internal_id);
			current_notification.notification_id = results.rows.item(i).notification_no;
			current_notification.title = results.rows.item(i).notification_subject;
			current_notification.typeid = results.rows.item(i).notification_typeid;
			current_notification.activityid = results.rows.item(i).notification_activityid;
			current_notification.so = results.rows.item(i).notification_so;
			current_notification.soldtoid = results.rows.item(i).notification_soldtoid;
			current_notification.shiptoid = results.rows.item(i).notification_shiptoid;
			current_notification.status = results.rows.item(i).notification_status;
			current_notification.priority = results.rows.item(i).notification_priority;
			current_notification.equipment = results.rows.item(i).notification_equipment;
			current_notification.objnr = results.rows.item(i).notification_objnr;
			current_notification.aufnr = results.rows.item(i).notification_aufnr;
			current_notification.signby = results.rows.item(i).notification_signby;
			current_notification.signbydisgn = results.rows.item(i).notification_signbydisgn;
			current_notification.signbydept = results.rows.item(i).notification_signbydept;
			current_notification.signbycontact = results.rows.item(i).notification_signbycontact;
			current_notification.signbyic =  results.rows.item(i).notification_signbyic;
			current_notification.requirestart = results.rows.item(i).notification_requiredstart;
			current_notification.requiredtime = results.rows.item(i).notification_requiredtime;
			current_notification.resp =  results.rows.item(i).notification_resp;
			current_notification.sapready = results.rows.item(i).notification_sapready;
			current_notification.operator = results.rows.item(i).notification_operator;

			array_notifications_upload[i] = current_notification;

		}

	}

	UploadNotification();
	//TestUpload();
	
	
	
	
}



function Download_Equipment () {
	
	DownloadEquipmentHistory(current_notification.equipment.equipmentid);
		
}
	
function TestConn() {
	
	var connectionStatus = false;
	connectionStatus = navigator.onLine ? "Test Connection Succesfully." : "Test Connection Failed.";      
	
	alert(connectionStatus);

}


function Saveshortby(val){
	
	shortby = val;
	
	//LoadNotifications();
}

function SaveSelectedStatus(param_selected_status){
	
	SelectedStatus = param_selected_status;
	
	LoadNotifications();
}



function LoadMessage(){
	
	
	db.transaction(function(tx) {
		tx.executeSql("select * from op_message where engineer_id  = '"+ current_login.user_id +"' ;", [], LoadMessageData, errorCB);
	});
	
}

function LoadMessageData(tx, results){
	array_message = [];
	
	var len = results.rows.length;
	
	if (array_message.length == 0) {

		for (var i=0; i< len; i++) {  
			array_message[i] = results.rows.item(i);
		}
		ClearMessageListTable();
		BuildMessageList(array_message);
	}
	
}

function ClearMessageListTable() {

	$("#" + TABLE_MESSAGE + " tr:gt(0)").remove();
}


function BuildMessageList(array_message){
	
	var str= "";
	for (var x = 0; x < array_message.length; x++) {
		 str = str + "<tr id='" + array_message[x].internal_id + "' >";
		 if(array_message[x].msg_isread == "1"){
			 str = str + "<td>"+ array_message[x].msg_date +"</td>";
			 str = str + "<td>"+ array_message[x].msg_text +"</td>"; 
		 } else {
			 str = str + "<td><b>"+ array_message[x].msg_date +"</b></td>";
			 str = str + "<td><b>"+ array_message[x].msg_text +"</b></td>"; 
		 }
		
		 str = str + "</tr>";

		 if( x == 0) {
			 $("#" + TABLE_MESSAGE + " tbody:last").append(str);	    
		 } else {
			 $("#" + TABLE_MESSAGE + " tr:last").after(str);
		 }

		
		 str = "";
	}

}
	
function UpdateMessage(){

	var d = new Date(); 
	var month = ("0" + (d.getMonth() + 1)).slice(-2);
	var day = ("0" + d.getDate()).slice(-2);
	var year = d.getFullYear();	
	var h = d.getHours();
	var m = d.getMinutes();
	var s = d.getSeconds();
	
	var today_date =  year + "-" + month + "-" + day + "  " + h + ":" + m + ":" + s ;
	
	db.transaction(function(tx) {
		tx.executeSql("update op_message set msg_isread = '1', msg_arrival_date = '" + today_date + "' where engineer_id = '" + current_login.user_id + "' ;", [], "", errorCB);
	});
	
	// added on 20150113
	db.transaction(function(tx){
		tx.executeSql("select count(*) as total_unread_msg from op_message where msg_isread = '0' and engineer_id = '"+ current_login.user_id +"' ;", [], LoadMessageCountLabel, errorCB);
	}, errorCB);
	
	
}
    
function PrintChecklist() {

	  $.ajax({
	        url: 'swordfish_checklist_template.html',
	        type: 'get',
	        async: false,
	        success: function(html) {       	
	        	htmltemplate_Checklist = html;
	        	window.requestFileSystem(LocalFileSystem.PERSISTENT, 0, gotFS_CHKLIST, FileFail);

	        }

		  });
	  
	
}
		  
function gotFS_CHKLIST(fileSystem) {
	
    fileSystem.root.getFile("swordfish_checklist_template.html", {create: true, exclusive: false}, gotFileEntry_CHKLIST, FileFail);

}	

function gotFileEntry_CHKLIST(fileEntry) {
	
    fileEntry.createWriter(gotFileWriter_CHKLIST, FileFail);
}	

function gotFileWriter_CHKLIST(writer) {
	
	var a = document.getElementById(DRP_CHECKLISTTYPE);
	var strchecklisttype = a.options[a.selectedIndex].text;
	
	//var templatechecklist_date = $("#checklist_date").text();
	var templatechecklist_date = date_now;
	var templatechecklist_name = $("#lbl_CheckList_HospitalName").text();
	var templatechecklist_dept = $("#lbl_CheckList_Dept").text();
	var templatechecklist_ModelNo = $("#lbl_CheckList_ModelNo").text();
	var templatechecklist_SN = $("#lbl_CheckList_SN").text();
	
	
	htmltemplate_Checklist = htmltemplate_Checklist.replace("#template_Type", (strchecklisttype== "")?"":strchecklisttype );
	htmltemplate_Checklist = htmltemplate_Checklist.replace("#template_Date", (templatechecklist_date== "")?"":templatechecklist_date );
	htmltemplate_Checklist = htmltemplate_Checklist.replace("#template_Name", (templatechecklist_name== "")?"":templatechecklist_name );
	htmltemplate_Checklist = htmltemplate_Checklist.replace("#template_dept", (templatechecklist_dept== "")?"":templatechecklist_dept );
	htmltemplate_Checklist = htmltemplate_Checklist.replace("#template_ModelNo", (templatechecklist_ModelNo== "")?"":templatechecklist_ModelNo );
	htmltemplate_Checklist = htmltemplate_Checklist.replace("#template_SN", (templatechecklist_SN== "")?"":templatechecklist_SN );
	
	if(current_notification.signature.notification_id != ""){
		
		///alert("current_notification.signature.notification_id NOT blank ");
		htmltemplate_Checklist = htmltemplate_Checklist.replace("#template_approvedby_img_src", "<img id ='tab_final_approvedby_img'  src = '"+ current_notification.signature.notification_signature +"' />" );
	} else {
		///alert("current_notification.signature.notification_id BLANK ");
		htmltemplate_Checklist = htmltemplate_Checklist.replace("#template_approvedby_img_src", "");
	}
	htmltemplate_Checklist = htmltemplate_Checklist.replace("#template_engineer", (current_login.user_firstname == "")?"":current_login.user_firstname);
	
	console.log("Testing notification");
	console.log(current_notification.signature.notification_id);
	
	

	
	var a = document.getElementById(DRP_CHECKLISTTYPE);
	var strchecklisttype = a.options[a.selectedIndex].value;
	
	

	db.transaction(function(tx) {
		tx.executeSql("SELECT op_checklist_detail.*, master_checklist.checklist_question FROM op_checklist_detail inner join master_checklist  on master_checklist.internal_id = op_checklist_detail.checklist_id " +
				"WHERE op_checklist_detail.checklist_header_id = (select op_checklist_header.internal_id from op_checklist_header where notification_id = '" + current_notification.internal_id + "') ;", [], function(tx, results)
                {
	                   // results is a http://dev.w3.org/html5/webdatabase/#sqlresultset .  
	                   // It has insertId, rowsAffected, and rows, which is
	                   // essentially (not exactly) an array of arrays. 
			var len = results.rows.length;
			
			array_checklist_template = [];
			 
			if (array_checklist_template.length == 0) {

				for (var i=0; i< len; i++) {  

					//current_notification.array_checklist = array_checklist_template[i];
					array_checklist_template[i] = results.rows.item(i);
					
				}
				
		   }
			
			
			
			
			console.log("Testarray");
			console.log(array_checklist_template);
			var str = "";
		if (array_checklist_template.length > 0) {
				
				for (var x = 0; x < array_checklist_template.length; x++) {
				    
				    str = str + "<tr id='" + array_checklist_template[x].internal_id + "'>";
				    str = str + "<td>" + array_checklist_template[x].checklist_question + "</td>";
				   
				    if(array_checklist_template[x].checklist_answer === undefined || array_checklist_template[x].checklist_answer == 'NULL' ){
				    	str = str + "<td class='hidden-480'><input class='m-wrap medium' type='text' placeholder='Test Result..' /> </td>";
				    }
				    else{
				    	
				    	str = str + "<td class='hidden-480'><input class='m-wrap medium' type='text' value='"+ array_checklist_template[x].checklist_answer +"' /> </td>";
				    }
		   
				    str = str + "</tr>";

				}
				
				
			}


			
			htmltemplate_Checklist = htmltemplate_Checklist.replace("#template_tr_parts", (str == "")?"":str);
			
		    writer.onwriteend = function(evt) {
		       
		        writer.truncate(0);
		        writer.onwriteend = function(evt) {
		            
		            writer.seek(writer.length);
		            writer.write(htmltemplate_Checklist);
		            writer.onwriteend = function(evt){

		            }
		            navigator.app.loadUrl("file://mnt/sdcard/swordfish_checklist_template.html", {openExternal : true});
		        };
		    };
		    
		    
		    writer.write(htmltemplate_Checklist);
		    
		    
		    
		    
		    
			
			
	                 }, errorCB);
	});
	
	
	
   
}  

function querydone()
{
	console.log("Testarray");
	console.log(array_checklist_template);
	var str = "";
if (array_checklist_template.length > 0) {
		
		for (var x = 0; x < array_checklist_template.length; x++) {
		    
		    str = str + "<tr id='" + array_checklist_template[x].internal_id + "'>";
		    str = str + "<td>" + array_checklist_template[x].checklist_question + "</td>";
		   
		    if(array_checklist_template[x].checklist_answer === undefined || array_checklist_template[x].checklist_answer == 'NULL' ){
		    	str = str + "<td class='hidden-480'><input class='m-wrap medium' type='text' placeholder='Test Result..' /> </td>";
		    }
		    else{
		    	
		    	str = str + "<td class='hidden-480'><input class='m-wrap medium' type='text' value='"+ array_checklist_template[x].checklist_answer +"' /> </td>";
		    }
   
		    str = str + "</tr>";

		}
		
		
	}


	
	htmltemplate_Checklist = htmltemplate_Checklist.replace("#template_tr_parts", (str == "")?"":str);
	
    writer.onwriteend = function(evt) {
       
        writer.truncate(0);
        writer.onwriteend = function(evt) {
            
            writer.seek(writer.length);
            writer.write(htmltemplate_Checklist);
            writer.onwriteend = function(evt){

            }
            navigator.app.loadUrl("file://mnt/sdcard/swordfish_checklist_template.html", {openExternal : true});
        };
    };
    
    
    writer.write(htmltemplate_Checklist);
    
}



function ReLoadChecklistData_Template(tx, results) {
	
	var len = results.rows.length;
	
	array_checklist_template = [];
	 
	if (array_checklist_template.length == 0) {

		for (var i=0; i< len; i++) {  

			//current_notification.array_checklist = array_checklist_template[i];
			array_checklist_template[i] = results.rows.item(i);
			
		}
		
   }
	
	querydone();
	
}







	

