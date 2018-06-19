// ------------------------------------------------------------------------------
//  <auto-generated>
//     This code was generated from a template.
// 
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Generated on 2018-02-16T11:17:32, by ESR Version 1.71.0.0 using ESR Database 
//  </auto-generated>
// ------------------------------------------------------------------------------


using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Collections.Generic;

namespace Ato.EN.IntegrationServices.CodeGenerationPAYEVNTEMP
{
    /// <summary>
    /// PAYEVNTEMP
    /// </summary>
    [DataContract(Name = "PAYEVNTEMP", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class PAYEVNTEMP
    {

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public Payee Payee { get; set; }
    }

    /// <summary>
    /// Payee Identifiers
    /// </summary>
    [DataContract(Name = "Identifiers", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class Identifiers
    {

        /// <summary>
        /// Payee TFN
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string TaxFileNumberId { get; set; }

        /// <summary>
        /// Contractor ABN
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string AustralianBusinessNumberId { get; set; }

        /// <summary>
        /// Payee Payroll ID
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string EmploymentPayrollNumberId { get; set; }
    }

    /// <summary>
    /// Payee Name Details
    /// </summary>
    [DataContract(Name = "PersonNameDetails", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class PersonNameDetails
    {

        /// <summary>
        /// Payee Family Name
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string FamilyNameT { get; set; }

        /// <summary>
        /// Payee First Name
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string GivenNameT { get; set; }

        /// <summary>
        /// Payee Other Name
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string OtherGivenNameT { get; set; }
    }

    /// <summary>
    /// Payee Demographic Details
    /// </summary>
    [DataContract(Name = "PersonDemographicDetails", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class PersonDemographicDetails
    {

        /// <summary>
        /// Payee Day of Birth
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public int? BirthDm { get; set; }

        /// <summary>
        /// Payee Month of Birth
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public int? BirthM { get; set; }

        /// <summary>
        /// Payee Year of Birth
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public int? BirthY { get; set; }
    }

    /// <summary>
    /// Address Details
    /// </summary>
    [DataContract(Name = "AddressDetails", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class AddressDetails
    {

        /// <summary>
        /// Payee Address Line 1
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Line1T { get; set; }

        /// <summary>
        /// Payee Address Line 2
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string Line2T { get; set; }

        /// <summary>
        /// Payee Suburb/Town
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string LocalityNameT { get; set; }

        /// <summary>
        /// Payee State/Territory
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 4)]
        public string StateOrTerritoryC { get; set; }

        /// <summary>
        /// Payee Postcode
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string PostcodeT { get; set; }

        /// <summary>
        /// Payee Country Code
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string CountryC { get; set; }
    }

    /// <summary>
    /// Electronic Contact
    /// </summary>
    [DataContract(Name = "ElectronicContact", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class ElectronicContact
    {

        /// <summary>
        /// Payee E-mail Address
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string ElectronicMailAddressT { get; set; }

        /// <summary>
        /// Payee Phone Number
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string TelephoneMinimalN { get; set; }
    }

    /// <summary>
    /// Employment Conditions
    /// </summary>
    [DataContract(Name = "EmployerConditions", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class EmployerConditions
    {

        /// <summary>
        /// Payee Commencement Date
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public DateTime? EmploymentStartD { get; set; }

        /// <summary>
        /// Payee Cessation Date
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public DateTime? EmploymentEndD { get; set; }
    }

    /// <summary>
    /// Payroll Run
    /// </summary>
    [DataContract(Name = "PayrollPeriod", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class PayrollPeriod
    {

        /// <summary>
        /// Period Start Date
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public DateTime StartD { get; set; }

        /// <summary>
        /// Period End Date
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public DateTime EndD { get; set; }

        /// <summary>
        /// Final Event Indicator
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public bool PayrollEventFinalI { get; set; }
    }

    /// <summary>
    /// Individual Non Business Payment Summary
    /// </summary>
    [DataContract(Name = "IndividualNonBusiness", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class IndividualNonBusiness
    {

        /// <summary>
        /// Payee Gross Payments
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public decimal GrossA { get; set; }

        /// <summary>
        /// Payee CDEP Payment Amount
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public decimal? CommunityDevelopmentEmploymentProjectA { get; set; }

        /// <summary>
        /// Payee Total INB PAYGW Amount
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public decimal TaxWithheldA { get; set; }

        /// <summary>
        /// Payee Exempt Foreign Income Amount
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 4)]
        public decimal? ExemptForeignEmploymentIncomeA { get; set; }
    }

    /// <summary>
    /// Voluntary Agreement Payment Summary
    /// </summary>
    [DataContract(Name = "VoluntaryAgreement", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class VoluntaryAgreement
    {

        /// <summary>
        /// Payee Voluntary Agreement Gross Payment
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public decimal GrossA { get; set; }

        /// <summary>
        /// Payee Total Voluntary Agreement PAYGW Amount
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public decimal TaxWithheldA { get; set; }
    }

    /// <summary>
    /// Business and Personal Services Income Payment Summary
    /// </summary>
    [DataContract(Name = "LabourHireArrangementPayment", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class LabourHireArrangementPayment
    {

        /// <summary>
        /// Payee Labour Hire Gross Payment
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public decimal GrossA { get; set; }

        /// <summary>
        /// Payee Total Labour Hire PAYGW Amount
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public decimal TaxWithheldA { get; set; }
    }

    /// <summary>
    /// Other Specified Payment Summary
    /// </summary>
    [DataContract(Name = "SpecifiedByRegulationPayment", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class SpecifiedByRegulationPayment
    {

        /// <summary>
        /// Payee Other Specified Gross Payments
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public decimal GrossA { get; set; }

        /// <summary>
        /// Payee Total Other Specified Payments PAYGW Amount
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public decimal TaxWithheldA { get; set; }
    }

    /// <summary>
    /// Joint Petroleum Development Area Payment Summary
    /// </summary>
    [DataContract(Name = "JointPetroleumDevelopmentAreaPayment", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class JointPetroleumDevelopmentAreaPayment
    {

        /// <summary>
        /// Payee JPDA Foreign Employment Income Gross Amount
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public decimal A { get; set; }

        /// <summary>
        /// Payee JPDA Foreign Employment Income Foreign Tax Paid
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public decimal ForeignWithholdingA { get; set; }

        /// <summary>
        /// Payee Total FEI JPDA PAYGW Amount
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public decimal TaxWithheldA { get; set; }
    }

    /// <summary>
    /// Working Holiday Maker Payment Summary
    /// </summary>
    [DataContract(Name = "WorkingHolidayMaker", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class WorkingHolidayMaker
    {

        /// <summary>
        /// Payee Working Holiday Maker Gross Payment
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public decimal GrossA { get; set; }

        /// <summary>
        /// Payee Working Holiday Maker PAYGW Amount
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public decimal TaxWithheldA { get; set; }
    }

    /// <summary>
    /// Foreign Employment Income Summary
    /// </summary>
    [DataContract(Name = "PaymentToForeignResident", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class PaymentToForeignResident
    {

        /// <summary>
        /// Payee Gross Payments Foreign Employment
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public decimal GrossA { get; set; }

        /// <summary>
        /// Payee Foreign Employment Income Foreign Tax Paid
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public decimal ForeignWithholdingA { get; set; }

        /// <summary>
        /// Payee Total FEI PAYGW Amount
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public decimal TaxWithheldA { get; set; }
    }

    /// <summary>
    /// Termination Payment Summary
    /// </summary>
    [CollectionDataContract(Name = "EmploymentTerminationPaymentCollection", Namespace = "http://www.sbr.gov.au/ato/payevntemp", ItemName = "EmploymentTerminationPayment")]
    public class EmploymentTerminationPaymentCollection : List<EmploymentTerminationPayment> { }

    /// <summary>
    /// Termination Payment Summary
    /// </summary>
    [DataContract(Name = "EmploymentTerminationPayment", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class EmploymentTerminationPayment
    {

        /// <summary>
        /// ETP Code
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string TypeC { get; set; }

        /// <summary>
        /// Payee ETP Payment Date
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public DateTime PaymentRecordPaymentEffectiveD { get; set; }

        /// <summary>
        /// Payee Termination Payment Tax Free Component
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public decimal SuperannuationTaxFreeComponentA { get; set; }

        /// <summary>
        /// Payee Termination Payment Taxable Component
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 4)]
        public decimal SuperannuationEmploymentTerminationTaxableComponentTotalA { get; set; }

        /// <summary>
        /// Payee Total ETP PAYGW Amount
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 5)]
        public decimal TaxWithheldA { get; set; }
    }

    /// <summary>
    /// Lump Sum Payment A
    /// </summary>
    [DataContract(Name = "LumpSumPaymentA", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class LumpSumPaymentA
    {

        /// <summary>
        /// Payee Lump Sum Payment A Type
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string LumpSumAC { get; set; }

        /// <summary>
        /// Payee Lump Sum Payment A
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public decimal LumpSumAA { get; set; }
    }

    /// <summary>
    /// Lump Sum Payments
    /// </summary>
    [DataContract(Name = "UnusedAnnualOrLongServiceLeavePayment", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class UnusedAnnualOrLongServiceLeavePayment
    {

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public LumpSumPaymentA LumpSumPaymentA { get; set; }

        /// <summary>
        /// Payee Lump Sum Payment B
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public decimal? LumpSumBA { get; set; }

        /// <summary>
        /// Payee Lump Sum Payment D
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public decimal? LumpSumDA { get; set; }

        /// <summary>
        /// Payee Lump Sum Payment E
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 4)]
        public decimal? LumpSumEA { get; set; }
    }

    /// <summary>
    /// Allowance Item
    /// </summary>
    [CollectionDataContract(Name = "AllowanceCollection", Namespace = "http://www.sbr.gov.au/ato/payevntemp", ItemName = "Allowance")]
    public class AllowanceCollection : List<Allowance> { }

    /// <summary>
    /// Allowance Item
    /// </summary>
    [DataContract(Name = "Allowance", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class Allowance
    {

        /// <summary>
        /// Allowance Type
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string TypeC { get; set; }

        /// <summary>
        /// Other Allowance Type
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string OtherAllowanceTypeDe { get; set; }

        /// <summary>
        /// Payee Allowance Amount
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public decimal IndividualNonBusinessEmploymentAllowancesA { get; set; }
    }

    /// <summary>
    /// Deduction Item
    /// </summary>
    [CollectionDataContract(Name = "DeductionCollection", Namespace = "http://www.sbr.gov.au/ato/payevntemp", ItemName = "Deduction")]
    public class DeductionCollection : List<Deduction> { }

    /// <summary>
    /// Deduction Item
    /// </summary>
    [DataContract(Name = "Deduction", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class Deduction
    {

        /// <summary>
        /// Deduction Type
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string TypeC { get; set; }

        /// <summary>
        /// Payee Deduction Amount
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public decimal A { get; set; }
    }

    /// <summary>
    /// Super Entitlement Year To Date
    /// </summary>
    [DataContract(Name = "SuperannuationContribution", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class SuperannuationContribution
    {

        /// <summary>
        /// Super Liability Amount
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public decimal? EmployerContributionsSuperannuationGuaranteeA { get; set; }

        /// <summary>
        /// OTE Amount
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public decimal? OrdinaryTimeEarningsA { get; set; }

        /// <summary>
        /// Reportable Employer Super Contribution
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public decimal? EmployerReportableA { get; set; }
    }

    /// <summary>
    /// Reportable Fringe Benefits Amount
    /// </summary>
    [DataContract(Name = "IncomeFringeBenefitsReportable", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class IncomeFringeBenefitsReportable
    {

        /// <summary>
        /// Payee RFB Taxable Amount
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public decimal? TaxableIncomeFringeBenefitsReportableA { get; set; }

        /// <summary>
        /// Payee RFB Exempt Amount
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public decimal? ExemptIncomeFringeBenefitsReportableA { get; set; }
    }

    /// <summary>
    /// Wage Item
    /// </summary>
    [DataContract(Name = "RemunerationIncomeTaxPayAsYouGoWithholding", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class RemunerationIncomeTaxPayAsYouGoWithholding
    {

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public PayrollPeriod PayrollPeriod { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public IndividualNonBusiness IndividualNonBusiness { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public VoluntaryAgreement VoluntaryAgreement { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public LabourHireArrangementPayment LabourHireArrangementPayment { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public SpecifiedByRegulationPayment SpecifiedByRegulationPayment { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public JointPetroleumDevelopmentAreaPayment JointPetroleumDevelopmentAreaPayment { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public WorkingHolidayMaker WorkingHolidayMaker { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public PaymentToForeignResident PaymentToForeignResident { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 9)]
        public EmploymentTerminationPaymentCollection EmploymentTerminationPaymentCollection { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 10)]
        public UnusedAnnualOrLongServiceLeavePayment UnusedAnnualOrLongServiceLeavePayment { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 11)]
        public AllowanceCollection AllowanceCollection { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 12)]
        public DeductionCollection DeductionCollection { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 13)]
        public SuperannuationContribution SuperannuationContribution { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 14)]
        public IncomeFringeBenefitsReportable IncomeFringeBenefitsReportable { get; set; }
    }

    /// <summary>
    /// Employment Details
    /// </summary>
    [DataContract(Name = "TFND", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class TFND
    {

        /// <summary>
        /// Payee Terminated Indicator
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string PaymentArrangementTerminationC { get; set; }

        /// <summary>
        /// Payee Residency Status
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public string ResidencyTaxPurposesPersonStatusC { get; set; }

        /// <summary>
        /// Basis of Payment Code
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string PaymentArrangementPaymentBasisC { get; set; }

        /// <summary>
        /// Tax Free Threshold Claimed
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 4)]
        public bool? TaxOffsetClaimTaxFreeThresholdI { get; set; }

        /// <summary>
        /// Study and Training Loan Repayment Indicator
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 5)]
        public bool? IncomeTaxPayAsYouGoWithholdingStudyAndTrainingLoanRepaymentI { get; set; }

        /// <summary>
        /// Student Financial Supplement Scheme Loan indicator
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 6)]
        public bool? StudentLoanStudentFinancialSupplementSchemeI { get; set; }
    }

    /// <summary>
    /// Payee Declaration
    /// </summary>
    [DataContract(Name = "Declaration", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class Declaration
    {

        /// <summary>
        /// Payee Declaration Acceptance Indicator
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public bool StatementAcceptedI { get; set; }

        /// <summary>
        /// Payee Date Declaration Signed
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public DateTime? SignatureD { get; set; }
    }

    /// <summary>
    /// Onboarding
    /// </summary>
    [DataContract(Name = "Onboarding", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class Onboarding
    {

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public TFND TFND { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public Declaration Declaration { get; set; }
    }

    /// <summary>
    /// Payee
    /// </summary>
    [DataContract(Name = "Payee", Namespace = "http://www.sbr.gov.au/ato/payevntemp")]
    public class Payee
    {

        [DataMember(EmitDefaultValue = false, Order = 1)]
        public Identifiers Identifiers { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 2)]
        public PersonNameDetails PersonNameDetails { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 3)]
        public PersonDemographicDetails PersonDemographicDetails { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 4)]
        public AddressDetails AddressDetails { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 5)]
        public ElectronicContact ElectronicContact { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 6)]
        public EmployerConditions EmployerConditions { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 7)]
        public RemunerationIncomeTaxPayAsYouGoWithholding RemunerationIncomeTaxPayAsYouGoWithholding { get; set; }

        [DataMember(EmitDefaultValue = false, Order = 8)]
        public Onboarding Onboarding { get; set; }
    }
}

