namespace Swordfish_v2_Core.CoreManagers
{
    using Jamila2.Database;
    using System;

    internal sealed class DataStructure
    {
        public StoredProceduresCollection StoredProcedures = new StoredProceduresCollection();
        public TablesCollection Tables = new TablesCollection();
        public ViewsCollection Views = new ViewsCollection();

        public class StoredProceduresCollection
        {
            public DataStructure.StoredProceduresGetCompletedJobVsJobClassification GetCompletedJobVsJobClassification = new DataStructure.StoredProceduresGetCompletedJobVsJobClassification("sp_GetCompletedJobVsJobClassification");
            public DataStructure.StoredProceduresGetCompletedVsPendingJob GetCompletedVsPendingJob = new DataStructure.StoredProceduresGetCompletedVsPendingJob("sp_GetCompletedVsPendingJob");
            public DataStructure.StoredProceduresGetCustomerSurveyByYear GetCustomerSurveyByYear = new DataStructure.StoredProceduresGetCustomerSurveyByYear("sp_CustomerSurveyByYear");
            public DataStructure.StoredProceduresGetEngineerOutstandingCompletedJob GetEngineerOutstandingCompletedJob = new DataStructure.StoredProceduresGetEngineerOutstandingCompletedJob("sp_GetEngineerOutstandingCompletedJob");
            public DataStructure.StoredProceduresGetEngineerOutstandingCompletedJobCauses GetEngineerOutstandingCompletedJobCauses = new DataStructure.StoredProceduresGetEngineerOutstandingCompletedJobCauses("sp_GetCausesByEngineerForUnFinishJob");
            public DataStructure.StoredProceduresGetEngineerOutstandingCompletedJobDamages GetEngineerOutstandingCompletedJobDamages = new DataStructure.StoredProceduresGetEngineerOutstandingCompletedJobDamages("sp_GetDamagesByEngineerForUnFinishJob");
            public DataStructure.StoredProceduresGetEngineerOutstandingCompletedJobParts GetEngineerOutstandingCompletedJobParts = new DataStructure.StoredProceduresGetEngineerOutstandingCompletedJobParts("sp_GetPartsByEngineerForUnFinishJob");
            public DataStructure.StoredProceduresGetEngineerOutstandingCompletedJobTimeline GetEngineerOutstandingCompletedJobTimeline = new DataStructure.StoredProceduresGetEngineerOutstandingCompletedJobTimeline("sp_GetTimestampByEngineerForUnFinishJob");
            public DataStructure.StoredProceduresGetEngineerUtilHours GetEngineerUtilHours = new DataStructure.StoredProceduresGetEngineerUtilHours("sp_GetEngineerHourUtilization");
            public DataStructure.StoredProceduresGetNotificationHistoryByEquipment GetNotificationHistoryByEquipment = new DataStructure.StoredProceduresGetNotificationHistoryByEquipment("GetNotificationByEquipment");
            public DataStructure.StoredProceduresGetSurveyRatingByMonthYear GetSurveyRatingByMonthYear = new DataStructure.StoredProceduresGetSurveyRatingByMonthYear("sp_GetSurveyRatingByYearMonth");
        }

        public class StoredProceduresGetCompletedJobVsJobClassification : DataStructure.TableBase
        {
            public DataStructure.TableBase.DataColumn Param_DChannel;
            public DataStructure.TableBase.DataColumn Param_Plant;
            public DataStructure.TableBase.DataColumn Param_Year;

            public StoredProceduresGetCompletedJobVsJobClassification(string PrivateName) : base(PrivateName)
            {
                this.Param_Year = new DataStructure.TableBase.DataColumn("@Year");
                this.Param_DChannel = new DataStructure.TableBase.DataColumn("@DChannel");
                this.Param_Plant = new DataStructure.TableBase.DataColumn("@Plant");
            }
        }

        public class StoredProceduresGetCompletedVsPendingJob : DataStructure.TableBase
        {
            public DataStructure.TableBase.DataColumn Param_DChannel;
            public DataStructure.TableBase.DataColumn Param_Month;
            public DataStructure.TableBase.DataColumn Param_Plant;
            public DataStructure.TableBase.DataColumn Param_Year;

            public StoredProceduresGetCompletedVsPendingJob(string PrivateName) : base(PrivateName)
            {
                this.Param_Year = new DataStructure.TableBase.DataColumn("@Year");
                this.Param_Month = new DataStructure.TableBase.DataColumn("@Month");
                this.Param_DChannel = new DataStructure.TableBase.DataColumn("@DChannel");
                this.Param_Plant = new DataStructure.TableBase.DataColumn("@Plant");
            }
        }

        public class StoredProceduresGetCustomerSurveyByYear : DataStructure.TableBase
        {
            public DataStructure.TableBase.DataColumn Param_DChannel;
            public DataStructure.TableBase.DataColumn Param_EngineerID;
            public DataStructure.TableBase.DataColumn Param_EquipmentProfile;
            public DataStructure.TableBase.DataColumn Param_Plant;
            public DataStructure.TableBase.DataColumn Param_Year;

            public StoredProceduresGetCustomerSurveyByYear(string PrivateName) : base(PrivateName)
            {
                this.Param_Year = new DataStructure.TableBase.DataColumn("@Year");
                this.Param_DChannel = new DataStructure.TableBase.DataColumn("@DChannel");
                this.Param_Plant = new DataStructure.TableBase.DataColumn("@Plant");
                this.Param_EngineerID = new DataStructure.TableBase.DataColumn("@EmloyeeID");
                this.Param_EquipmentProfile = new DataStructure.TableBase.DataColumn("@EuipmentProfile");
            }
        }

        public class StoredProceduresGetEngineerOutstandingCompletedJob : DataStructure.TableBase
        {
            public DataStructure.TableBase.DataColumn Param_DChannel;
            public DataStructure.TableBase.DataColumn Param_EngineerID;
            public DataStructure.TableBase.DataColumn Param_EquipmentProfile;
            public DataStructure.TableBase.DataColumn Param_Month;
            public DataStructure.TableBase.DataColumn Param_Plant;
            public DataStructure.TableBase.DataColumn Param_Year;

            public StoredProceduresGetEngineerOutstandingCompletedJob(string PrivateName) : base(PrivateName)
            {
                this.Param_Year = new DataStructure.TableBase.DataColumn("@Year");
                this.Param_Month = new DataStructure.TableBase.DataColumn("@Month");
                this.Param_Plant = new DataStructure.TableBase.DataColumn("@Plant");
                this.Param_DChannel = new DataStructure.TableBase.DataColumn("@DChannel");
                this.Param_EngineerID = new DataStructure.TableBase.DataColumn("@EngineerID");
                this.Param_EquipmentProfile = new DataStructure.TableBase.DataColumn("@EuipmentProfile");
            }

            internal string ActualTableName
            {
                get
                {
                    return base.PrivateName;
                }
            }
        }

        public class StoredProceduresGetEngineerOutstandingCompletedJobCauses : DataStructure.TablesCollection.TableMasterCause
        {
            public DataStructure.TableBase.DataColumn Param_EngineerID;
            public DataStructure.TableBase.DataColumn Param_Month;
            public DataStructure.TableBase.DataColumn Param_Year;

            public StoredProceduresGetEngineerOutstandingCompletedJobCauses(string PrivateName) : base(PrivateName)
            {
                this.Param_Year = new DataStructure.TableBase.DataColumn("@Year");
                this.Param_Month = new DataStructure.TableBase.DataColumn("@Month");
                this.Param_EngineerID = new DataStructure.TableBase.DataColumn("@EngineerID");
            }
        }

        public class StoredProceduresGetEngineerOutstandingCompletedJobDamages : DataStructure.TablesCollection.TableMasterDamage
        {
            public DataStructure.TableBase.DataColumn Param_EngineerID;
            public DataStructure.TableBase.DataColumn Param_Month;
            public DataStructure.TableBase.DataColumn Param_Year;

            public StoredProceduresGetEngineerOutstandingCompletedJobDamages(string PrivateName) : base(PrivateName)
            {
                this.Param_Year = new DataStructure.TableBase.DataColumn("@Year");
                this.Param_Month = new DataStructure.TableBase.DataColumn("@Month");
                this.Param_EngineerID = new DataStructure.TableBase.DataColumn("@EngineerID");
            }
        }

        public class StoredProceduresGetEngineerOutstandingCompletedJobParts : DataStructure.TablesCollection.TableOpParts
        {
            public DataStructure.TableBase.DataColumn Param_EngineerID;
            public DataStructure.TableBase.DataColumn Param_Month;
            public DataStructure.TableBase.DataColumn Param_Year;

            public StoredProceduresGetEngineerOutstandingCompletedJobParts(string PrivateName) : base(PrivateName)
            {
                this.Param_Year = new DataStructure.TableBase.DataColumn("@Year");
                this.Param_Month = new DataStructure.TableBase.DataColumn("@Month");
                this.Param_EngineerID = new DataStructure.TableBase.DataColumn("@EngineerID");
            }
        }

        public class StoredProceduresGetEngineerOutstandingCompletedJobTimeline : DataStructure.TablesCollection.TableOpTimeStamp
        {
            public DataStructure.TableBase.DataColumn Param_EngineerID;
            public DataStructure.TableBase.DataColumn Param_Month;
            public DataStructure.TableBase.DataColumn Param_Year;

            public StoredProceduresGetEngineerOutstandingCompletedJobTimeline(string PrivateName) : base(PrivateName)
            {
                this.Param_Year = new DataStructure.TableBase.DataColumn("@Year");
                this.Param_Month = new DataStructure.TableBase.DataColumn("@Month");
                this.Param_EngineerID = new DataStructure.TableBase.DataColumn("@EngineerID");
            }
        }

        public class StoredProceduresGetEngineerUtilHours : DataStructure.TablesCollection.TableMasterCause
        {
            public DataStructure.TableBase.DataColumn Param_DChannel;
            public DataStructure.TableBase.DataColumn Param_EngineerID;
            public DataStructure.TableBase.DataColumn Param_EquipmentProfile;
            public DataStructure.TableBase.DataColumn Param_Plant;
            public DataStructure.TableBase.DataColumn Param_TargetHour;
            public DataStructure.TableBase.DataColumn Param_Year;

            public StoredProceduresGetEngineerUtilHours(string PrivateName) : base(PrivateName)
            {
                this.Param_Year = new DataStructure.TableBase.DataColumn("@Year");
                this.Param_TargetHour = new DataStructure.TableBase.DataColumn("@TargetHour");
                this.Param_EngineerID = new DataStructure.TableBase.DataColumn("@Engineer");
                this.Param_EquipmentProfile = new DataStructure.TableBase.DataColumn("@EuipmentProfile");
                this.Param_DChannel = new DataStructure.TableBase.DataColumn("@DChannel");
                this.Param_Plant = new DataStructure.TableBase.DataColumn("@Plant");
            }
        }

        public class StoredProceduresGetNotificationHistoryByEquipment : DataStructure.TableBase
        {
            public DataStructure.TableBase.DataColumn Param_EquipmentID;

            public StoredProceduresGetNotificationHistoryByEquipment(string PrivateName) : base(PrivateName)
            {
                this.Param_EquipmentID = new DataStructure.TableBase.DataColumn("@EquipmentID");
            }
        }

        public class StoredProceduresGetSurveyRatingByMonthYear : DataStructure.TableBase
        {
            public DataStructure.TableBase.DataColumn Param_DChannel;
            public DataStructure.TableBase.DataColumn Param_EngineerID;
            public DataStructure.TableBase.DataColumn Param_EquipmentProfile;
            public DataStructure.TableBase.DataColumn Param_Month;
            public DataStructure.TableBase.DataColumn Param_Plant;
            public DataStructure.TableBase.DataColumn Param_Year;

            public StoredProceduresGetSurveyRatingByMonthYear(string PrivateName) : base(PrivateName)
            {
                this.Param_Year = new DataStructure.TableBase.DataColumn("@Year");
                this.Param_Month = new DataStructure.TableBase.DataColumn("@Month");
                this.Param_DChannel = new DataStructure.TableBase.DataColumn("@DChannel");
                this.Param_Plant = new DataStructure.TableBase.DataColumn("@Plant");
                this.Param_EngineerID = new DataStructure.TableBase.DataColumn("@EmloyeeID");
                this.Param_EquipmentProfile = new DataStructure.TableBase.DataColumn("@EuipmentProfile");
            }
        }

        public abstract class TableBase : DataStructureBase.Table
        {
            public TableBase(string ActualDBName) : base("", ActualDBName)
            {
            }

            public string ActualTableName
            {
                get
                {
                    return base.PrivateName;
                }
            }

            public class DataColumn : DataStructureBase.Table.DataColumn
            {
                public DataColumn(string ActualDBName) : base("", ActualDBName)
                {
                }

                public string ActualFieldName
                {
                    get
                    {
                        return base.PrivateName;
                    }
                }
            }
        }

        public class TablesCollection
        {
            public TableDamageCauseRelation DamageCauseRelation = new TableDamageCauseRelation("master_doc_relation");
            public TableLogActions LogActions = new TableLogActions("log_actions");
            public TableLogError LogError = new TableLogError("log_error");
            public TableMasterCause MasterCause = new TableMasterCause("master_cause");
            public TableMasterCheckList MasterCheckList = new TableMasterCheckList("master_checklist");
            public TableMasterCheckListRelation MasterCheckListRelation = new TableMasterCheckListRelation("master_checklist_relation");
            public TableMasterCheckListType MasterCheckListType = new TableMasterCheckListType("master_checklist_type");
            public TableMasterCustomer MasterCustomer = new TableMasterCustomer("master_customers");
            public TableMasterDamage MasterDamage = new TableMasterDamage("master_damage");
            public TableMasterEquipment MasterEquipment = new TableMasterEquipment("master_equipment");
            public TableMasterLookUp MasterLookUp = new TableMasterLookUp("master_lookup");
            public TableMasterQuickNotes MasterQuickNotes = new TableMasterQuickNotes("master_quick_notes");
            public TableMasterUsers MasterUsers = new TableMasterUsers("master_users");
            public TableOpCauses OpCauses = new TableOpCauses("op_causes");
            public TableOpCheckListDetail OpCheckListDetail = new TableOpCheckListDetail("op_checklist_detail");
            public TableOpCheckListHeader OpCheckListHeader = new TableOpCheckListHeader("op_checklist_header");
            public TableOpDamages OpDamages = new TableOpDamages("op_damages");
            public TableOpEngineers OpEngineers = new TableOpEngineers("op_engineers");
            public TableOpNotification OpNotification = new TableOpNotification("op_notification");
            public TableOpParts OpParts = new TableOpParts("op_parts");
            public TableOpPartsOnVehicle OpPartsOnVehicle = new TableOpPartsOnVehicle("op_parts_vehicle");
            public TableOpQuotation OpQuotation = new TableOpQuotation("op_quotation");
            public TableOpQuotationDetail OpQuotationDetail = new TableOpQuotationDetail("op_quotation_detail");
            public TableOpSignature OpSignature = new TableOpSignature("op_signature");
            public TableOpSurvey OpSurvey = new TableOpSurvey("op_survey");
            public TableOpTimeStamp OpTimeStamp = new TableOpTimeStamp("op_timestamp");
            public TableTravelBack OpTravelBack = new TableTravelBack("op_travelback");
            public TableSyncInfo SyncInfo = new TableSyncInfo("tmp_sync");

            public class TableDamageCauseRelation : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn EquipmentProfileID;
                public DataStructure.TableBase.DataColumn GroupID;
                public DataStructure.TableBase.DataColumn RelationshipType;

                public TableDamageCauseRelation(string ActualDBName) : base(ActualDBName)
                {
                    this.EquipmentProfileID = new DataStructure.TableBase.DataColumn("equipment_profile");
                    this.GroupID = new DataStructure.TableBase.DataColumn("doc_grp_id");
                    this.RelationshipType = new DataStructure.TableBase.DataColumn("doc_type");
                }
            }

            public class TableLogActions : DataStructureBase.Table
            {
                public DataStructure.TableBase.DataColumn Description;
                public DataStructure.TableBase.DataColumn LogBy;
                public DataStructure.TableBase.DataColumn LogDateTime;
                public DataStructure.TableBase.DataColumn ReffID;

                public TableLogActions(string PrivateName) : base("", PrivateName)
                {
                    this.LogDateTime = new DataStructure.TableBase.DataColumn("log_datetime");
                    this.Description = new DataStructure.TableBase.DataColumn("log_desc");
                    this.LogBy = new DataStructure.TableBase.DataColumn("log_by");
                    this.ReffID = new DataStructure.TableBase.DataColumn("log_reffid");
                }

                internal string ActualTableName
                {
                    get
                    {
                        return base.PrivateName;
                    }
                }
            }

            public class TableLogError : DataStructureBase.Table
            {
                public DataStructure.TableBase.DataColumn Description;
                public DataStructure.TableBase.DataColumn LogBy;
                public DataStructure.TableBase.DataColumn LogDateTime;
                public DataStructure.TableBase.DataColumn LogID;

                public TableLogError(string PrivateName) : base("", PrivateName)
                {
                    this.LogID = new DataStructure.TableBase.DataColumn("log_id");
                    this.LogDateTime = new DataStructure.TableBase.DataColumn("log_datetime");
                    this.Description = new DataStructure.TableBase.DataColumn("log_desc");
                    this.LogBy = new DataStructure.TableBase.DataColumn("log_by");
                }

                internal string ActualTableName
                {
                    get
                    {
                        return base.PrivateName;
                    }
                }
            }

            public class TableMasterCause : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn CauseCode;
                public DataStructure.TableBase.DataColumn CauseDescription;
                public DataStructure.TableBase.DataColumn CauseGroup;
                public DataStructure.TableBase.DataColumn dtCreated;

                public TableMasterCause(string ActualDBName) : base(ActualDBName)
                {
                    this.CauseCode = new DataStructure.TableBase.DataColumn("cause_code");
                    this.CauseDescription = new DataStructure.TableBase.DataColumn("cause_desc");
                    this.CauseGroup = new DataStructure.TableBase.DataColumn("cause_group");
                    this.dtCreated = new DataStructure.TableBase.DataColumn("dt_created");
                }
            }

            public class TableMasterCheckList : DataStructureBase.Table
            {
                public DataStructure.TableBase.DataColumn CheckListActive;
                public DataStructure.TableBase.DataColumn ChecklistQuestion;
                public DataStructure.TableBase.DataColumn CheckListSeq;
                public DataStructure.TableBase.DataColumn CheckListType;
                public DataStructure.TableBase.DataColumn InternalID;

                public TableMasterCheckList(string PrivateName) : base("", PrivateName)
                {
                    this.InternalID = new DataStructure.TableBase.DataColumn("internal_id");
                    this.ChecklistQuestion = new DataStructure.TableBase.DataColumn("checklist_question");
                    this.CheckListActive = new DataStructure.TableBase.DataColumn("checklist_active");
                    this.CheckListType = new DataStructure.TableBase.DataColumn("checklist_type");
                    this.CheckListSeq = new DataStructure.TableBase.DataColumn("checklist_seq");
                }

                internal string ActualTableName
                {
                    get
                    {
                        return base.PrivateName;
                    }
                }
            }

            public class TableMasterCheckListRelation : DataStructureBase.Table
            {
                public DataStructure.TableBase.DataColumn ChecklistType;
                public DataStructure.TableBase.DataColumn DistChannel;
                public DataStructure.TableBase.DataColumn PlantNo;

                public TableMasterCheckListRelation(string PrivateName) : base("", PrivateName)
                {
                    this.ChecklistType = new DataStructure.TableBase.DataColumn("checklist_type");
                    this.DistChannel = new DataStructure.TableBase.DataColumn("dchannel");
                    this.PlantNo = new DataStructure.TableBase.DataColumn("plant");
                }

                internal string ActualTableName
                {
                    get
                    {
                        return base.PrivateName;
                    }
                }
            }

            public class TableMasterCheckListType : DataStructureBase.Table
            {
                public DataStructure.TableBase.DataColumn InternalID;
                public DataStructure.TableBase.DataColumn TypeName;

                public TableMasterCheckListType(string PrivateName) : base("", PrivateName)
                {
                    this.InternalID = new DataStructure.TableBase.DataColumn("internal_id");
                    this.TypeName = new DataStructure.TableBase.DataColumn("type_name");
                }

                internal string ActualTableName
                {
                    get
                    {
                        return base.PrivateName;
                    }
                }
            }

            public class TableMasterCustomer : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn City;
                public DataStructure.TableBase.DataColumn Country;
                public DataStructure.TableBase.DataColumn Currency;
                public DataStructure.TableBase.DataColumn CustomerID;
                public DataStructure.TableBase.DataColumn DistrChannel;
                public DataStructure.TableBase.DataColumn Division;
                public DataStructure.TableBase.DataColumn dtCreated;
                public DataStructure.TableBase.DataColumn Fax;
                public DataStructure.TableBase.DataColumn Incoterms;
                public DataStructure.TableBase.DataColumn Incoterms2;
                public DataStructure.TableBase.DataColumn Name1;
                public DataStructure.TableBase.DataColumn Name2;
                public DataStructure.TableBase.DataColumn PaymentTerms;
                public DataStructure.TableBase.DataColumn PO;
                public DataStructure.TableBase.DataColumn Region;
                public DataStructure.TableBase.DataColumn SalesOrg;
                public DataStructure.TableBase.DataColumn Street;
                public DataStructure.TableBase.DataColumn Tel;

                public TableMasterCustomer(string ActualDBName) : base(ActualDBName)
                {
                    this.Incoterms = new DataStructure.TableBase.DataColumn("cust_incoterms");
                    this.Incoterms2 = new DataStructure.TableBase.DataColumn("cust_incoterms2");
                    this.CustomerID = new DataStructure.TableBase.DataColumn("cust_customer");
                    this.Country = new DataStructure.TableBase.DataColumn("cust_country");
                    this.Name1 = new DataStructure.TableBase.DataColumn("cust_name1");
                    this.Name2 = new DataStructure.TableBase.DataColumn("cust_name2");
                    this.City = new DataStructure.TableBase.DataColumn("cust_city");
                    this.PO = new DataStructure.TableBase.DataColumn("cust_po");
                    this.Region = new DataStructure.TableBase.DataColumn("cust_region");
                    this.Division = new DataStructure.TableBase.DataColumn("cust_division");
                    this.Street = new DataStructure.TableBase.DataColumn("cust_street");
                    this.Tel = new DataStructure.TableBase.DataColumn("cust_tel1");
                    this.Fax = new DataStructure.TableBase.DataColumn("cust_fax");
                    this.SalesOrg = new DataStructure.TableBase.DataColumn("cust_salesorg");
                    this.DistrChannel = new DataStructure.TableBase.DataColumn("cust_distrchannel");
                    this.Currency = new DataStructure.TableBase.DataColumn("cust_currency");
                    this.PaymentTerms = new DataStructure.TableBase.DataColumn("cust_peymentterms");
                    this.dtCreated = new DataStructure.TableBase.DataColumn("dt_created");
                }
            }

            public class TableMasterDamage : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn DamageCode;
                public DataStructure.TableBase.DataColumn DamageDescription;
                public DataStructure.TableBase.DataColumn DamageGroup;
                public DataStructure.TableBase.DataColumn dtCreated;

                public TableMasterDamage(string ActualDBName) : base(ActualDBName)
                {
                    this.DamageCode = new DataStructure.TableBase.DataColumn("damage_code");
                    this.DamageDescription = new DataStructure.TableBase.DataColumn("damage_desc");
                    this.DamageGroup = new DataStructure.TableBase.DataColumn("damage_group");
                    this.dtCreated = new DataStructure.TableBase.DataColumn("dt_created");
                }
            }

            public class TableMasterEquipment : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn dtCreated;
                public DataStructure.TableBase.DataColumn EquipmentDescription;
                public DataStructure.TableBase.DataColumn EquipmentID;
                public DataStructure.TableBase.DataColumn EquipmentLocation;
                public DataStructure.TableBase.DataColumn EquipmentObject;
                public DataStructure.TableBase.DataColumn EquipmentProfile;
                public DataStructure.TableBase.DataColumn Equipmentsnr;

                public TableMasterEquipment(string ActualDBName) : base(ActualDBName)
                {
                    this.EquipmentID = new DataStructure.TableBase.DataColumn("equipment_id");
                    this.EquipmentDescription = new DataStructure.TableBase.DataColumn("equipment_desc");
                    this.Equipmentsnr = new DataStructure.TableBase.DataColumn("equipment_snr");
                    this.EquipmentObject = new DataStructure.TableBase.DataColumn("equipment_obj");
                    this.EquipmentLocation = new DataStructure.TableBase.DataColumn("equipment_location");
                    this.dtCreated = new DataStructure.TableBase.DataColumn("dt_created");
                    this.EquipmentProfile = new DataStructure.TableBase.DataColumn("equipment_profile");
                }
            }

            public class TableMasterLookUp : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn dtCreated;
                public DataStructure.TableBase.DataColumn MasterDescription;
                public DataStructure.TableBase.DataColumn MasterID;
                public DataStructure.TableBase.DataColumn MasterType;

                public TableMasterLookUp(string ActualDBName) : base(ActualDBName)
                {
                    this.MasterID = new DataStructure.TableBase.DataColumn("master_id");
                    this.MasterDescription = new DataStructure.TableBase.DataColumn("master_desc");
                    this.MasterType = new DataStructure.TableBase.DataColumn("master_type");
                    this.dtCreated = new DataStructure.TableBase.DataColumn("dt_created");
                }
            }

            public class TableMasterQuickNotes : DataStructureBase.Table
            {
                public DataStructure.TableBase.DataColumn active;
                public DataStructure.TableBase.DataColumn Description;
                public DataStructure.TableBase.DataColumn InternalID;
                public DataStructure.TableBase.DataColumn Language;

                public TableMasterQuickNotes(string PrivateName) : base("", PrivateName)
                {
                    this.InternalID = new DataStructure.TableBase.DataColumn("internal_id");
                    this.Description = new DataStructure.TableBase.DataColumn("description");
                    this.active = new DataStructure.TableBase.DataColumn("active");
                    this.Language = new DataStructure.TableBase.DataColumn("lang");
                }

                internal string ActualTableName
                {
                    get
                    {
                        return base.PrivateName;
                    }
                }
            }

            public class TableMasterUsers : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn DistributionChannel;
                public DataStructure.TableBase.DataColumn dtCreated;
                public DataStructure.TableBase.DataColumn FirstName;
                public DataStructure.TableBase.DataColumn InternalID;
                public DataStructure.TableBase.DataColumn LastName;
                public DataStructure.TableBase.DataColumn Password;
                public DataStructure.TableBase.DataColumn Plant;
                public DataStructure.TableBase.DataColumn Status;
                public DataStructure.TableBase.DataColumn UserID;
                public DataStructure.TableBase.DataColumn VehicleNumber;

                public TableMasterUsers(string ActualDBName) : base(ActualDBName)
                {
                    this.InternalID = new DataStructure.TableBase.DataColumn("internal_id");
                    this.UserID = new DataStructure.TableBase.DataColumn("user_id");
                    this.Password = new DataStructure.TableBase.DataColumn("user_password");
                    this.FirstName = new DataStructure.TableBase.DataColumn("user_firstname");
                    this.LastName = new DataStructure.TableBase.DataColumn("user_lastname");
                    this.Status = new DataStructure.TableBase.DataColumn("user_active");
                    this.dtCreated = new DataStructure.TableBase.DataColumn("dt_created");
                    this.DistributionChannel = new DataStructure.TableBase.DataColumn("user_dchannel");
                    this.VehicleNumber = new DataStructure.TableBase.DataColumn("user_vno");
                    this.Plant = new DataStructure.TableBase.DataColumn("user_plant");
                }
            }

            public class TableOpCauses : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn CauseCode;
                public DataStructure.TableBase.DataColumn CauseDescription;
                public DataStructure.TableBase.DataColumn CauseGroup;
                public DataStructure.TableBase.DataColumn CauseOrder;
                public DataStructure.TableBase.DataColumn InternalID;
                public DataStructure.TableBase.DataColumn NotificationID;
                public DataStructure.TableBase.DataColumn OpSys;

                public TableOpCauses(string ActualDBName) : base(ActualDBName)
                {
                    this.InternalID = new DataStructure.TableBase.DataColumn("internal_id");
                    this.NotificationID = new DataStructure.TableBase.DataColumn("cause_notification");
                    this.CauseGroup = new DataStructure.TableBase.DataColumn("cause_group");
                    this.CauseCode = new DataStructure.TableBase.DataColumn("cause_code");
                    this.CauseDescription = new DataStructure.TableBase.DataColumn("cause_desc");
                    this.CauseOrder = new DataStructure.TableBase.DataColumn("cause_order");
                    this.OpSys = new DataStructure.TableBase.DataColumn("op_sys");
                }
            }

            public class TableOpCheckListDetail : DataStructureBase.Table
            {
                public DataStructure.TableBase.DataColumn Answer;
                public DataStructure.TableBase.DataColumn CheckListID;
                public DataStructure.TableBase.DataColumn HeaderID;
                public DataStructure.TableBase.DataColumn InternalID;

                public TableOpCheckListDetail(string PrivateName) : base("", PrivateName)
                {
                    this.InternalID = new DataStructure.TableBase.DataColumn("internal_id");
                    this.HeaderID = new DataStructure.TableBase.DataColumn("checklist_header_id");
                    this.CheckListID = new DataStructure.TableBase.DataColumn("checklist_id");
                    this.Answer = new DataStructure.TableBase.DataColumn("checklist_answer");
                }

                internal string ActualTableName
                {
                    get
                    {
                        return base.PrivateName;
                    }
                }
            }

            public class TableOpCheckListHeader : DataStructureBase.Table
            {
                public DataStructure.TableBase.DataColumn AcquisitaionModelNo;
                public DataStructure.TableBase.DataColumn AcquisitionModelSN;
                public DataStructure.TableBase.DataColumn CheckListType;
                public DataStructure.TableBase.DataColumn Date;
                public DataStructure.TableBase.DataColumn Department;
                public DataStructure.TableBase.DataColumn HospitalName;
                public DataStructure.TableBase.DataColumn InternalID;
                public DataStructure.TableBase.DataColumn ModelNo;
                public DataStructure.TableBase.DataColumn NotificationID;
                public DataStructure.TableBase.DataColumn SerialNo;
                public DataStructure.TableBase.DataColumn TreadmillModelNo;
                public DataStructure.TableBase.DataColumn TreadmillSN;

                public TableOpCheckListHeader(string PrivateName) : base("", PrivateName)
                {
                    this.InternalID = new DataStructure.TableBase.DataColumn("internal_id");
                    this.NotificationID = new DataStructure.TableBase.DataColumn("notification_id");
                    this.HospitalName = new DataStructure.TableBase.DataColumn("checklist_hospital_name");
                    this.ModelNo = new DataStructure.TableBase.DataColumn("checklist_model_no");
                    this.SerialNo = new DataStructure.TableBase.DataColumn("checklist_sn");
                    this.Date = new DataStructure.TableBase.DataColumn("checklist_date");
                    this.AcquisitaionModelNo = new DataStructure.TableBase.DataColumn("checklist_acquisition_model_no");
                    this.AcquisitionModelSN = new DataStructure.TableBase.DataColumn("checklist_acquisition_model_sn");
                    this.TreadmillModelNo = new DataStructure.TableBase.DataColumn("checklist_treadmill_model_no");
                    this.TreadmillSN = new DataStructure.TableBase.DataColumn("checklist_treadmill_model_sn");
                    this.Department = new DataStructure.TableBase.DataColumn("checklist_department");
                    this.CheckListType = new DataStructure.TableBase.DataColumn("checklist_type");
                }

                internal string ActualTableName
                {
                    get
                    {
                        return base.PrivateName;
                    }
                }
            }

            public class TableOpDamages : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn DamageCode;
                public DataStructure.TableBase.DataColumn DamageDescription;
                public DataStructure.TableBase.DataColumn DamageGroup;
                public DataStructure.TableBase.DataColumn DamageOrder;
                public DataStructure.TableBase.DataColumn InternalID;
                public DataStructure.TableBase.DataColumn NotificationID;
                public DataStructure.TableBase.DataColumn OpSys;

                public TableOpDamages(string ActualDBName) : base(ActualDBName)
                {
                    this.InternalID = new DataStructure.TableBase.DataColumn("internal_id");
                    this.NotificationID = new DataStructure.TableBase.DataColumn("damage_notification");
                    this.DamageGroup = new DataStructure.TableBase.DataColumn("damage_group");
                    this.DamageCode = new DataStructure.TableBase.DataColumn("damage_code");
                    this.DamageDescription = new DataStructure.TableBase.DataColumn("damage_desc");
                    this.DamageOrder = new DataStructure.TableBase.DataColumn("damage_order");
                    this.OpSys = new DataStructure.TableBase.DataColumn("op_sys");
                }
            }

            public class TableOpEngineers : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn EngineerID;
                public DataStructure.TableBase.DataColumn Lead;
                public DataStructure.TableBase.DataColumn NotificationID;
                public DataStructure.TableBase.DataColumn OpSys;

                public TableOpEngineers(string ActualDBName) : base(ActualDBName)
                {
                    this.NotificationID = new DataStructure.TableBase.DataColumn("emp_notification");
                    this.EngineerID = new DataStructure.TableBase.DataColumn("emp_engineer");
                    this.Lead = new DataStructure.TableBase.DataColumn("emp_lead");
                    this.OpSys = new DataStructure.TableBase.DataColumn("op_sys");
                }
            }

            public class TableOpNotification : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn AcitivtyID;
                public DataStructure.TableBase.DataColumn Aufnr;
                public DataStructure.TableBase.DataColumn EquipmentID;
                public DataStructure.TableBase.DataColumn InternalID;
                public DataStructure.TableBase.DataColumn NotificationNo;
                public DataStructure.TableBase.DataColumn NotificationSo;
                public DataStructure.TableBase.DataColumn Objnr;
                public DataStructure.TableBase.DataColumn Operator;
                public DataStructure.TableBase.DataColumn Priority;
                public DataStructure.TableBase.DataColumn RequiredStart;
                public DataStructure.TableBase.DataColumn RequiredTime;
                public DataStructure.TableBase.DataColumn Resp;
                public DataStructure.TableBase.DataColumn SAPReady;
                public DataStructure.TableBase.DataColumn ShipToID;
                public DataStructure.TableBase.DataColumn SignBy;
                public DataStructure.TableBase.DataColumn SignByContact;
                public DataStructure.TableBase.DataColumn SignByDept;
                public DataStructure.TableBase.DataColumn SignByDisgn;
                public DataStructure.TableBase.DataColumn SignByIC;
                public DataStructure.TableBase.DataColumn SoldToID;
                public DataStructure.TableBase.DataColumn Status;
                public DataStructure.TableBase.DataColumn Subject;
                public DataStructure.TableBase.DataColumn TypeID;

                public TableOpNotification(string ActualDBName) : base(ActualDBName)
                {
                    this.InternalID = new DataStructure.TableBase.DataColumn("internal_id");
                    this.Subject = new DataStructure.TableBase.DataColumn("notification_subject");
                    this.TypeID = new DataStructure.TableBase.DataColumn("notification_typeid");
                    this.AcitivtyID = new DataStructure.TableBase.DataColumn("notification_activityid");
                    this.NotificationNo = new DataStructure.TableBase.DataColumn("notification_no");
                    this.NotificationSo = new DataStructure.TableBase.DataColumn("notification_so");
                    this.SoldToID = new DataStructure.TableBase.DataColumn("notification_soldtoid");
                    this.ShipToID = new DataStructure.TableBase.DataColumn("notification_shiptoid");
                    this.Status = new DataStructure.TableBase.DataColumn("notification_status");
                    this.Priority = new DataStructure.TableBase.DataColumn("notification_priority");
                    this.EquipmentID = new DataStructure.TableBase.DataColumn("notification_equipment");
                    this.Objnr = new DataStructure.TableBase.DataColumn("notification_objnr");
                    this.Aufnr = new DataStructure.TableBase.DataColumn("notification_aufnr");
                    this.SignBy = new DataStructure.TableBase.DataColumn("notification_signby");
                    this.SignByDisgn = new DataStructure.TableBase.DataColumn("notification_signbydisgn");
                    this.SignByDept = new DataStructure.TableBase.DataColumn("notification_signbydept");
                    this.SignByContact = new DataStructure.TableBase.DataColumn("notification_signbycontact");
                    this.SignByIC = new DataStructure.TableBase.DataColumn("notification_signbyic");
                    this.RequiredStart = new DataStructure.TableBase.DataColumn("notification_requiredstart");
                    this.RequiredTime = new DataStructure.TableBase.DataColumn("notification_requiredtime");
                    this.Resp = new DataStructure.TableBase.DataColumn("notification_resp");
                    this.SAPReady = new DataStructure.TableBase.DataColumn("notification_sapready");
                    this.Operator = new DataStructure.TableBase.DataColumn("notification_operator");
                }
            }

            public class TableOpParts : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn Consumption;
                public DataStructure.TableBase.DataColumn InternalID;
                public DataStructure.TableBase.DataColumn InUse;
                public DataStructure.TableBase.DataColumn Material;
                public DataStructure.TableBase.DataColumn MaterialDescription;
                public DataStructure.TableBase.DataColumn NotificationID;
                public DataStructure.TableBase.DataColumn OpConsumedFromMobile;
                public DataStructure.TableBase.DataColumn OpConsumedFromSAP;
                public DataStructure.TableBase.DataColumn OpSys;
                public DataStructure.TableBase.DataColumn OpUpdatedFromMobile;
                public DataStructure.TableBase.DataColumn OpUpdatedFromSAP;
                public DataStructure.TableBase.DataColumn PartNo;
                public DataStructure.TableBase.DataColumn Preset;
                public DataStructure.TableBase.DataColumn Quantity;
                public DataStructure.TableBase.DataColumn QuantityConsumpt;
                public DataStructure.TableBase.DataColumn QuantityReserved;
                public DataStructure.TableBase.DataColumn Unit;
                public DataStructure.TableBase.DataColumn VehicleNo;

                public TableOpParts(string ActualDBName) : base(ActualDBName)
                {
                    this.InternalID = new DataStructure.TableBase.DataColumn("internal_id");
                    this.NotificationID = new DataStructure.TableBase.DataColumn("part_notification");
                    this.PartNo = new DataStructure.TableBase.DataColumn("part_no");
                    this.Quantity = new DataStructure.TableBase.DataColumn("part_quantity");
                    this.Unit = new DataStructure.TableBase.DataColumn("part_unit");
                    this.Consumption = new DataStructure.TableBase.DataColumn("part_consumption");
                    this.Material = new DataStructure.TableBase.DataColumn("part_material");
                    this.MaterialDescription = new DataStructure.TableBase.DataColumn("part_material_desc");
                    this.InUse = new DataStructure.TableBase.DataColumn("part_inuse");
                    this.Preset = new DataStructure.TableBase.DataColumn("part_preset");
                    this.QuantityReserved = new DataStructure.TableBase.DataColumn("part_reserved");
                    this.QuantityConsumpt = new DataStructure.TableBase.DataColumn("part_consumed");
                    this.OpConsumedFromMobile = new DataStructure.TableBase.DataColumn("op_consumed_from_mobile");
                    this.OpConsumedFromSAP = new DataStructure.TableBase.DataColumn("op_consumed_from_sap");
                    this.OpUpdatedFromMobile = new DataStructure.TableBase.DataColumn("op_updated_from_mobile");
                    this.OpUpdatedFromSAP = new DataStructure.TableBase.DataColumn("op_updated_from_sap");
                    this.OpSys = new DataStructure.TableBase.DataColumn("op_sys");
                    this.VehicleNo = new DataStructure.TableBase.DataColumn("part_vehicleno");
                }
            }

            public class TableOpPartsOnVehicle : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn AvailableQuantity;
                public DataStructure.TableBase.DataColumn ConsumedQuantity;
                public DataStructure.TableBase.DataColumn Description;
                public DataStructure.TableBase.DataColumn OldPartNo;
                public DataStructure.TableBase.DataColumn PartNo;
                public DataStructure.TableBase.DataColumn ReservedQuantity;
                public DataStructure.TableBase.DataColumn UnitOfMeasurement;
                public DataStructure.TableBase.DataColumn UpdatedDate;
                public DataStructure.TableBase.DataColumn VehicleID;

                public TableOpPartsOnVehicle(string ActualDBName) : base(ActualDBName)
                {
                    this.PartNo = new DataStructure.TableBase.DataColumn("part_id");
                    this.OldPartNo = new DataStructure.TableBase.DataColumn("part_id_old");
                    this.Description = new DataStructure.TableBase.DataColumn("part_desc");
                    this.AvailableQuantity = new DataStructure.TableBase.DataColumn("part_avail");
                    this.ReservedQuantity = new DataStructure.TableBase.DataColumn("part_reserved");
                    this.ConsumedQuantity = new DataStructure.TableBase.DataColumn("part_consumed");
                    this.UnitOfMeasurement = new DataStructure.TableBase.DataColumn("part_uom");
                    this.VehicleID = new DataStructure.TableBase.DataColumn("part_vehicleid");
                    this.UpdatedDate = new DataStructure.TableBase.DataColumn("part_date");
                }
            }

            public class TableOpQuotation : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn Attn;
                public DataStructure.TableBase.DataColumn Currency;
                public DataStructure.TableBase.DataColumn CustomerAddress;
                public DataStructure.TableBase.DataColumn CustomerName;
                public DataStructure.TableBase.DataColumn DeliveryTerm;
                public DataStructure.TableBase.DataColumn EngineerID;
                public DataStructure.TableBase.DataColumn FaxEmail;
                public DataStructure.TableBase.DataColumn Incoterm1;
                public DataStructure.TableBase.DataColumn Incoterm2;
                public DataStructure.TableBase.DataColumn InternalID;
                public DataStructure.TableBase.DataColumn Notice;
                public DataStructure.TableBase.DataColumn NotificationID;
                public DataStructure.TableBase.DataColumn PaymentTerm;
                public DataStructure.TableBase.DataColumn QuotationDate;
                public DataStructure.TableBase.DataColumn QuotationNo;
                public DataStructure.TableBase.DataColumn Status;
                public DataStructure.TableBase.DataColumn UserStatus;
                public DataStructure.TableBase.DataColumn ValidFrom;
                public DataStructure.TableBase.DataColumn ValidityDays;
                public DataStructure.TableBase.DataColumn ValidTo;

                public TableOpQuotation(string ActualDBName) : base(ActualDBName)
                {
                    this.InternalID = new DataStructure.TableBase.DataColumn("internal_id");
                    this.NotificationID = new DataStructure.TableBase.DataColumn("quotation_notification");
                    this.QuotationNo = new DataStructure.TableBase.DataColumn("quotation_no");
                    this.Notice = new DataStructure.TableBase.DataColumn("quotation_notice");
                    this.UserStatus = new DataStructure.TableBase.DataColumn("quotation_userstatus");
                    this.ValidFrom = new DataStructure.TableBase.DataColumn("quotation_validfrom");
                    this.ValidTo = new DataStructure.TableBase.DataColumn("quotation_validto");
                    this.EngineerID = new DataStructure.TableBase.DataColumn("quotation_engineer");
                    this.Status = new DataStructure.TableBase.DataColumn("quotation_status");
                    this.Currency = new DataStructure.TableBase.DataColumn("quotation_currency");
                    this.Incoterm1 = new DataStructure.TableBase.DataColumn("quotation_incoterm1");
                    this.Incoterm2 = new DataStructure.TableBase.DataColumn("quotation_incoterm2");
                    this.PaymentTerm = new DataStructure.TableBase.DataColumn("quotation_paymentterm");
                    this.DeliveryTerm = new DataStructure.TableBase.DataColumn("quotation_deliveryterm");
                    this.Attn = new DataStructure.TableBase.DataColumn("quotation_attn");
                    this.FaxEmail = new DataStructure.TableBase.DataColumn("quotation_fax_email");
                    this.QuotationDate = new DataStructure.TableBase.DataColumn("quotation_date");
                    this.CustomerName = new DataStructure.TableBase.DataColumn("quotation_customer_name");
                    this.CustomerAddress = new DataStructure.TableBase.DataColumn("quotation_customer_address");
                    this.ValidityDays = new DataStructure.TableBase.DataColumn("quotation_validity");
                }
            }

            public class TableOpQuotationDetail : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn Description;
                public DataStructure.TableBase.DataColumn DetailNo;
                public DataStructure.TableBase.DataColumn DetailQuotation;
                public DataStructure.TableBase.DataColumn Discount;
                public DataStructure.TableBase.DataColumn InternalID;
                public DataStructure.TableBase.DataColumn PartNo;
                public DataStructure.TableBase.DataColumn Quantity;
                public DataStructure.TableBase.DataColumn Rate;
                public DataStructure.TableBase.DataColumn TotalPrice;
                public DataStructure.TableBase.DataColumn Unit;

                public TableOpQuotationDetail(string ActualDBName) : base(ActualDBName)
                {
                    this.InternalID = new DataStructure.TableBase.DataColumn("internal_id");
                    this.DetailNo = new DataStructure.TableBase.DataColumn("detail_no");
                    this.DetailQuotation = new DataStructure.TableBase.DataColumn("detail_quotation");
                    this.Description = new DataStructure.TableBase.DataColumn("detail_description");
                    this.Quantity = new DataStructure.TableBase.DataColumn("detail_quantity");
                    this.Unit = new DataStructure.TableBase.DataColumn("detail_unit");
                    this.Rate = new DataStructure.TableBase.DataColumn("detail_rate");
                    this.PartNo = new DataStructure.TableBase.DataColumn("detail_partno");
                    this.Discount = new DataStructure.TableBase.DataColumn("detail_discount");
                    this.TotalPrice = new DataStructure.TableBase.DataColumn("detail_total_price");
                }
            }

            public class TableOpSignature : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn Contact;
                public DataStructure.TableBase.DataColumn Department;
                public DataStructure.TableBase.DataColumn Designation;
                public DataStructure.TableBase.DataColumn Name;
                public DataStructure.TableBase.DataColumn NotificationID;
                public DataStructure.TableBase.DataColumn Signature;

                public TableOpSignature(string ActualDBName) : base(ActualDBName)
                {
                    this.NotificationID = new DataStructure.TableBase.DataColumn("notification_id");
                    this.Signature = new DataStructure.TableBase.DataColumn("notification_signature");
                    this.Name = new DataStructure.TableBase.DataColumn("signature_name");
                    this.Contact = new DataStructure.TableBase.DataColumn("signature_contact");
                    this.Department = new DataStructure.TableBase.DataColumn("signature_dept");
                    this.Designation = new DataStructure.TableBase.DataColumn("signature_designation");
                }
            }

            public class TableOpSurvey : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn Comments;
                public DataStructure.TableBase.DataColumn InternalID;
                public DataStructure.TableBase.DataColumn NotificationID;
                public DataStructure.TableBase.DataColumn Remarks;
                public DataStructure.TableBase.DataColumn SurveyDate;

                public TableOpSurvey(string ActualDBName) : base(ActualDBName)
                {
                    this.InternalID = new DataStructure.TableBase.DataColumn("internal_id");
                    this.NotificationID = new DataStructure.TableBase.DataColumn("survey_notification");
                    this.Comments = new DataStructure.TableBase.DataColumn("survey_comments");
                    this.Remarks = new DataStructure.TableBase.DataColumn("survey_remarks");
                    this.SurveyDate = new DataStructure.TableBase.DataColumn("survey_date");
                }
            }

            public class TableOpTimeStamp : DataStructure.TableBase
            {
                public DataStructure.TableBase.DataColumn Description;
                public DataStructure.TableBase.DataColumn InternalID;
                public DataStructure.TableBase.DataColumn IsShared;
                public DataStructure.TableBase.DataColumn JobBy;
                public DataStructure.TableBase.DataColumn JobDate;
                public DataStructure.TableBase.DataColumn JobEnd;
                public DataStructure.TableBase.DataColumn JobStart;
                public DataStructure.TableBase.DataColumn JobTravel;
                public DataStructure.TableBase.DataColumn JobTravelEnd;
                public DataStructure.TableBase.DataColumn JobTravelStart;
                public DataStructure.TableBase.DataColumn JobWaiting;
                public DataStructure.TableBase.DataColumn JobWaitingEnd;
                public DataStructure.TableBase.DataColumn JobWaitingStart;
                public DataStructure.TableBase.DataColumn NotificationID;
                public DataStructure.TableBase.DataColumn OpUpdatedFromSAP;
                public DataStructure.TableBase.DataColumn Status;

                public TableOpTimeStamp(string ActualDBName) : base(ActualDBName)
                {
                    this.InternalID = new DataStructure.TableBase.DataColumn("internal_id");
                    this.NotificationID = new DataStructure.TableBase.DataColumn("tstamp_notification");
                    this.JobDate = new DataStructure.TableBase.DataColumn("job_date");
                    this.JobTravel = new DataStructure.TableBase.DataColumn("job_travel");
                    this.JobWaiting = new DataStructure.TableBase.DataColumn("job_waiting");
                    this.JobTravelStart = new DataStructure.TableBase.DataColumn("job_travel_start");
                    this.JobTravelEnd = new DataStructure.TableBase.DataColumn("job_travel_end");
                    this.JobWaitingStart = new DataStructure.TableBase.DataColumn("job_waiting_start");
                    this.JobWaitingEnd = new DataStructure.TableBase.DataColumn("job_waiting_end");
                    this.JobStart = new DataStructure.TableBase.DataColumn("job_start");
                    this.JobEnd = new DataStructure.TableBase.DataColumn("job_end");
                    this.Description = new DataStructure.TableBase.DataColumn("job_description");
                    this.Status = new DataStructure.TableBase.DataColumn("job_status");
                    this.JobBy = new DataStructure.TableBase.DataColumn("job_by");
                    this.OpUpdatedFromSAP = new DataStructure.TableBase.DataColumn("op_updated_from_sap");
                    this.IsShared = new DataStructure.TableBase.DataColumn("op_shared");
                }
            }

            public class TableSyncInfo : DataStructureBase.Table
            {
                public DataStructure.TableBase.DataColumn LastSyncDate;

                public TableSyncInfo(string PrivateName) : base("", PrivateName)
                {
                    this.LastSyncDate = new DataStructure.TableBase.DataColumn("dt_last_sync");
                }

                internal string ActualTableName
                {
                    get
                    {
                        return base.PrivateName;
                    }
                }
            }

            public class TableTravelBack : DataStructureBase.Table
            {
                public DataStructure.TableBase.DataColumn InternalID;
                public DataStructure.TableBase.DataColumn NotificationID;
                public DataStructure.TableBase.DataColumn TimeEnd;
                public DataStructure.TableBase.DataColumn TimeStart;

                public TableTravelBack(string PrivateName) : base("", PrivateName)
                {
                    this.InternalID = new DataStructure.TableBase.DataColumn("internal_id");
                    this.NotificationID = new DataStructure.TableBase.DataColumn("notification_id");
                    this.TimeStart = new DataStructure.TableBase.DataColumn("time_start");
                    this.TimeEnd = new DataStructure.TableBase.DataColumn("time_end");
                }

                internal string ActualTableName
                {
                    get
                    {
                        return base.PrivateName;
                    }
                }
            }
        }

        public class ViewsCollection
        {
        }
    }
}
