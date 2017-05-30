using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for WebObjects
/// </summary>
public class WebObjects
{
    public class obj_notification
    {
        public string internal_id;
        public string notification_id = "";
    
        public string title = "";
        public string typeid = "";
   
        public string activityid = "";
        public string so = "";
        public string soldtoid = "";
        public string shiptoid = "";
        public string status = "";
        public string statusdesc = "";
        public string priority = "";
        public string prioritydesc = "";
    
        public string objnr = "";
        public string aufnr = "";
        public string signby = "";
        public string signbydisgn = "";
        public string signbydept = "";
        public string signbycontact = "";
        public string signbyic = "";
        public string requirestart = "";
        public string requiredtime = "";
        public string resp = "";
        public string sapready = "";
        public string obj_operator = "";
        public string equipment = "";

    }

    public class obj_timestamp
    {
        public string current_date;
    
        public string internal_id = "";
        public string tstamp_notification = "";
        public string job_date = "";
        public string job_travel = "";
        public string job_waiting = "";
        public string job_travel_start = "";
        public string job_travel_end = "";
        public string job_waiting_start = "";
        public string job_waiting_end = "";
        public string job_start = "";
        public string job_end = "";
        public string job_description = "";
        public string job_status = "";
        public string job_by = "";
        public string op_updated_from_sap = "";
        public string op_shared = "";
    }

    public class obj_op_damages
    {
        public string damage_group = "";
        public string damage_code = "";
        public string damage_desc = "";
    
        public string internal_id = "";
        public string damage_notification = "";
        public string damage_order = "";
        public string op_sys = "";
    }

    public class obj_op_causes
    {
        public string cause_group = "";
        public string cause_code = "";
        public string cause_desc = "";

        public string internal_id = "";
        public string cause_notification = "";
        public string cause_order = "";
        public string op_sys = "";
    }

    public class obj_part
    {
        public string internal_id = "";
	    public string part_notification = "";
	    public string part_no = "";
	    public string part_quantity = "";
	    public string part_unit = "";
	    public string part_consumption = "";
	    public string part_material = "";
	    public string part_material_desc = "";
	    public string part_inuse = "";
	    public string part_preset= ""; 
	    public string op_sys = "";
	    public string part_consumed = "";
	    public string op_consumed_from_mobile = "";
	    public string op_consumed_from_sap = ""; 
	    public string op_updated_from_mobile = "";
	    public string op_updated_from_sap = ""; 
	    public string part_reserved = "";
	    public string part_vehicleno = "";
    }

    public class obj_equipment
    {
        public string equipmentid = "";
	    public string equipmentdesc = "";
	    public string equipment_snr = "";
	    public string equipment_obj = "";
	    public string equipment_location = "";
	    public string equipment_profile = "";
	
    }

    public class obj_customers
    {
        public string cust_incoterms = "";
	    public string cust_incoterms2 = "";
	    public string cust_customer = "";
	    public string cust_country = "";
	    public string cust_name1 = "";
	    public string cust_name2 = "";
	    public string cust_city = "";
	    public string cust_po = "";
	    public string cust_region = "";
	    public string cust_division = "";
	    public string cust_street = "";
	    public string cust_tel1 = "";
	    public string cust_fax = "";
	    public string cust_salesorg = "";
	    public string cust_distrchannel = "";
	    public string cust_currency = "";
	    public string cust_peymentterms = "";
    }

    public class obj_checklist
    {
        public string internal_id = "";
        public string notification_id = "";
        public string checklist_hospital_name = "";
        public string checklist_model_no = "";
        public string checklist_sn = "";
        public string checklist_date = "";
        public string checklist_acquisition_model_no = "";
        public string checklist_acquisition_model_sn = "";
        public string checklist_treadmill_model_no = "";
        public string checklist_treadmill_model_sn = "";
        public string checklist_department = "";
        public string checklist_type = "";
    }

    public class obj_signature
    {
        public string notification_id = "";
	    public string notification_signature = "";
	    public string signature_name = "";
	    public string signature_contact = "";
	    public string signature_dept = "";
	    public string signature_designation = "";
    }

    public class obj_survey
    {
        public string internal_id = "";
	    public string survey_notification = "";
	    public string survey_comments = "";
	    public string survey_date = "";
	    public string survey_remarks = "";
    }

    public class obj_checklist_header
    {
	    public string internal_id = "";
	    public string notification_id = "";
	    public string checklist_hospital_name = "";
	    public string checklist_model_no = "";
	    public string checklist_sn = "";
	    public string checklist_date = "";
	    public string checklist_acquisition_model_no = "";
	    public string checklist_acquisition_model_sn = "";
	    public string checklist_treadmill_model_no = "";
	    public string checklist_treadmill_model_sn = "";
	    public string checklist_department = "";
	    public string checklist_type = "";
    }

    public class obj_checklist_detail
    {
	    public string internal_id = "";
	    public string checklist_header_id = "";
	    public string checklist_id = "";
	    public string checklist_answer = "";
    }

    public class obj_master_equipment
    {
        public string equipment_id = "";
	    public string equipment_desc = "";
	    public string equipment_snr = "";
	    public string equipment_obj = "";
	    public string equipment_location = "";
	    public string equipment_profile = "";
    }

    public class obj_master_lookup
    {
        public string master_id = "";
	    public string master_desc = "";
	    public string master_type = "";
    }

    public class obj_master_damage
    {
        public string damage_code = "";
	    public string damage_desc = "";
	    public string damage_group = "";
    }

    public class obj_master_cause
    {
        public string cause_code = "";
	    public string cause_desc = "";
	    public string cause_group = "";
    }

    public class obj_quotation_header
    {
        public string internal_id = ""; 
	    public string quotation_notification = "";
	    public string quotation_no = ""; 
	    public string quotation_notice = ""; 
	    public string quotation_userstatus = ""; 
	    public string quotation_validfrom = ""; 
	    public string quotation_validto = ""; 
	    public string quotation_engineer = ""; 
	    public string quotation_status = ""; 
	    public string quotation_currency = ""; 
	    public string quotation_incoterm1 = ""; 
	    public string quotation_incoterm2 = ""; 
	    public string quotation_paymentterm = ""; 
	    public string quotation_deliveryterm = ""; 
	    public string quotation_attn = ""; 
	    public string quotation_fax_email = ""; 
	    public string quotation_date = ""; 
	    public string quotation_customer_name = ""; 
	    public string quotation_customer_address = ""; 
	    public string quotation_validity = ""; 
    }

    public class obj_quotation_detail
    {
        public string internal_id = "";
	    public string detail_no = "";
	    public string detail_quotation = "";
	    public string detail_description = "";
	    public string detail_quantity = "";
	    public string detail_unit = "";
	    public string detail_rate = "";
	    public string detail_discount = "";
	    public string detail_partno = "";
	    public string detail_total_price = "";
    }

    public class obj_travelback
    {
        public string notification_id = "";
	    public string time_start = "";
	    public string time_end = "";
        public string internal_id = "";
    }

    public class obj_message
    {
        public string internal_id = "";
        public string engineer_id = "";
        public string msg_text = "";
        public string msg_date = "";
        public string msg_arrival_date = "";
        public string msg_isread = "";
    }

}