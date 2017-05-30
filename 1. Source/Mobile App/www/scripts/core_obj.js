//*** obj_notification


function obj_notification (internal_id) {
    this.internal_id = internal_id;
    this.notification_id = "";
    
    this.title = "";
    this.typeid = "";
   
    this.activityid = "";
    this.so = "";
    this.soldtoid = "";
    this.shiptoid = "";
    this.status = "";
    this.statusdesc = "";
    this.priority = "";
    this.prioritydesc = "";
    
    this.objnr = "";
    this.aufnr = "";
    this.signby = "";
    this.signbydisgn = "";
    this.signbydept = "";
    this.signbycontact = "";
    this.signbyic = "";
    this.requirestart = "";
    this.requiredtime = "";
    this.resp = "";
    this.sapready = "";
    this.obj_operator = "";
    this.survey = "";
    this.signature = ""; 
    this.quotation = ""; 
    
    this.array_timeline = null;
    this.array_damages = null;
    this.array_causes = null;
    this.array_parts = null;
    this.activity = null;
    this.equipment = null;
    this.customer = null;
    this.timeline = null;
    
    this.array_equipment = null;
    this.array_related = null;
    this.array_master_damages = null;
    this.array_master_damagecode = null;
    this.array_master_causes = null;
    this.array_master_causecode = null;
    this.array_checklist = null;
    this.array_quotation = null;
    
    // init
    function init() {
        this.internal_id = "";
        this.notification_id = "";
        
    }
    
    function sortTimelineByDate () {
        
        if (this.array_timeline != null) {
            // use bubble sort
        }
    }
}

//*** obj_timestamp

function obj_timestamp (
    notification_id    
) {
    
    //this.current_date = current_date;
    
    this.internal_id = "";
    this.tstamp_notification = notification_id;
    this.job_date = "";
    this.job_travel = "";
    this.job_waiting = "";
    this.job_travel_start = "";
    this.job_travel_end = "";
    this.job_waiting_start = "";
    this.job_waiting_end = "";
    this.job_start = "";
    this.job_end = "";
    this.job_description = "";
    this.job_status = "";
    this.job_by = "";
    this.op_updated_from_sap = "";
    this.op_shared = "";
    
    /*
     *  TS: Travel Start
     *  TE: Travel End
     *  WS: Waiting Start
     *  JS: Job Start
     *  JE: Job End
     */
    
    // init
    function init () {
        this.current_date = null;
        this.current_status = "JS";
        this.travel_start = this.travel_end = this.waiting_start = this.waiting_end = this.work_start = this.work_end = null;        
    }
    
    function getTravelTime () {
        
        var result = 0;
        
        return result;   // in minutes
    }
    
    function getWaitingTime () {
        
        var result = 0;
        
        return result;   // in minutes
    }
    
    function getWorkingTime () {
        
        var result = 0;
        
        return result;   // in minutes
    }
    
}

function obj_op_damages (
    notification_id 
    
) {

    this.internal_id = "";
    this.damage_notification = notification_id;
    this.damage_group = "";
    this.damage_code = "";
    this.damage_desc = "";
    this.damage_order = "";
    this.op_sys = "";
    
}

function obj_op_causes (
		notification_id
    
) {
	
    this.internal_id = "";
    this.cause_notification = notification_id;
    this.cause_group = "";
    this.cause_code = "";
    this.cause_desc = "";
    this.cause_order = "";
    this.op_sys = "";
    
    
}

//*** obj_part
function obj_part () {
    
	this.internal_id = "";
	this.part_notification = "";
	this.part_no = "";
	this.part_quantity = "";
	this.part_unit = "";
	this.part_consumption = "";
	this.part_material = "";
	this.part_material_desc = "";
	this.part_inuse = "";
	this.part_preset= ""; 
	this.op_sys = "";
	this.part_consumed = "";
	this.op_consumed_from_mobile = "";
	this.op_consumed_from_sap = ""; 
	this.op_updated_from_mobile = "";
	this.op_updated_from_sap = ""; 
	this.part_reserved = "";
	this.part_vehicleno = "";
	
}

function obj_masterlookup (master_id) {
	
	this.master_id = master_id;
	this.master_desc = "";
	this.master_type = "";
		
		
}

function obj_equipment (equipment_id){
	
	this.equipmentid = equipment_id;
	this.equipmentdesc = "";
	this.equipment_snr = "";
	this.equipment_obj = "";
	this.equipment_location = "";
	this.equipment_profile = "";
	
	
	
}

function obj_customer (customer_id) {

	this.cust_incoterms = "";
	this.cust_incoterms2 = "";
	this.cust_customer = customer_id;
	this.cust_country = "";
	this.cust_name1 = "";
	this.cust_name2 = "";
	this.cust_city = "";
	this.cust_po = "";
	this.cust_region = "";
	this.cust_division = "";
	this.cust_street = "";
	this.cust_tel1 = "";
	this.cust_fax = "";
	this.cust_salesorg = "";
	this.cust_distrchannel = "";
	this.cust_currency = "";
	this.cust_peymentterms = "";
	
}

//*** obj_currentlogin 
function obj_currentlogin(employee_id){

	this.internal_id = "";
	this.user_id = employee_id;
	this.user_firstname = "";
	this.user_lastname = "";
	this.user_active = "";
	this.user_dchannel = "";
	this.user_vno = "";
	this.user_plant = "";
	
	
	
	
}

function obj_checklist (notification_id) {
	
    this.internal_id = "";
    this.notification_id = notification_id;
    this.checklist_hospital_name = "";
    this.checklist_model_no = "";
    this.checklist_sn = "";
    this.checklist_date = "";
    this.checklist_acquisition_model_no = "";
    this.checklist_acquisition_model_sn = "";
    this.checklist_treadmill_model_no = "";
    this.checklist_treadmill_model_sn = "";
    this.checklist_department = "";
    this.checklist_type = "";

    
}

function obj_signature(notification_id) {
	
	
	this.notification_id = notification_id;
	this.notification_signature = "";
	this.notification_signature_json = "";
	this.signature_name = "";
	this.signature_contact = "";
	this.signature_dept = "";
	this.signature_designation = "";

	
}

function obj_survay (notification_id) {
	
	this.internal_id = "";
	this.survey_notification = notification_id;
	this.survey_comments = "";
	this.survey_date = "";
	this.survey_remarks = "";


	
} 

function obj_checklist_header (notification_id) {
	
	this.internal_id = "";
	this.notification_id = notification_id;
	this.checklist_hospital_name = "";
	this.checklist_model_no = "";
	this.checklist_sn = "";
	this.checklist_date = "";
	this.checklist_acquisition_model_no = "";
	this.checklist_acquisition_model_sn = "";
	this.checklist_treadmill_model_no = "";
	this.checklist_treadmill_model_sn = "";
	this.checklist_department = "";
	this.checklist_type = "";
	
}

function obj_checklist_detail (header_id) {
	
	this.internal_id = "";
	this.checklist_header_id = header_id;
	this.checklist_id = "";
	this.checklist_answer = "";
	
}

function obj_master_equipment () {
	
	this.equipment_id = "";
	this.equipment_desc = "";
	this.equipment_snr = "";
	this.equipment_obj = "";
	this.equipment_location = "";
	this.equipment_profile = "";
	
	
}


function obj_master_lookup () {
	
	this.master_id = "";
	this.master_desc = "";
	this.master_type = "";

}

function obj_master_damage () {
	
	this.damage_code = "";
	this.damage_desc = "";
	this.damage_group = "";

	
}


function obj_master_cause () {
	
	this.cause_code = "";
	this.cause_desc = "";
	this.cause_group = "";
	
}

function obj_quotation_header (notification_id) {
	
	this.internal_id = ""; 
	this.quotation_notification = notification_id;
	this.quotation_no = ""; 
	this.quotation_notice = ""; 
	this.quotation_userstatus = ""; 
	this.quotation_validfrom = ""; 
	this.quotation_validto = ""; 
	this.quotation_engineer = ""; 
	this.quotation_status = ""; 
	this.quotation_currency = ""; 
	this.quotation_incoterm1 = ""; 
	this.quotation_incoterm2 = ""; 
	this.quotation_paymentterm = ""; 
	this.quotation_deliveryterm = ""; 
	this.quotation_attn = ""; 
	this.quotation_fax_email = ""; 
	this.quotation_date = ""; 
	this.quotation_customer_name = ""; 
	this.quotation_customer_address = ""; 
	this.quotation_validity = ""; 
	this.quotation_isdownloaded = "";
	
}

function obj_quotation_detail (quotation_no) {
	
	this.internal_id = "";
	this.detail_no = "";
	this.detail_quotation = "";
	this.detail_description = "";
	this.detail_quantity = "";
	this.detail_unit = "";
	this.detail_rate = "";
	this.detail_discount = "";
	this.detail_partno = "";
	this.detail_total_price = "";
	
}


function obj_travelback (notification_id) {

	this.notification_id = notification_id;
	this.time_start = "";
	this.time_end = "";
	this.internal_id = "";


}

function obj_message(internal_id)
{
	this.internal_id = "";
	this.engineer_id = "";
	this.msg_text = "";
	this.msg_date = "";
	this.msg_arrival_date = "";
	this.msg_isread = "";
}



