CREATE OR REPLACE FUNCTION public.getdarjpaymentbystatus(
	"paramStatus" integer)
    RETURNS TABLE(
		"DARJPaymentId" bigint, 
		"AccountId" bigint, 
		"OperationId" bigint, 
		"TaxId" character varying, 
		"ContributorTaxId" character varying, 
		"ReferenceNumber" character varying, 
		"PrincipalValue" numeric, 
		"FineValue" numeric, 
		"InterestValue" numeric, 
		"MonetaryValue" numeric, 
		"TotalValue" numeric, 
		"RateValue" numeric, 
		"DueDate" timestamp without time zone, 
		"PaymentDate" timestamp without time zone, 
		"CodeRevenue" character varying, 
		"StateRegistration" character varying, 
		"OriginDocument" bigint, 
		"RateValueType" bigint, 
		"Description" character varying, 
		"Identifier" character varying, 
		"Status" integer, 
		"Attempts" integer, 
		"ExternalIdentifier" bigint, 
		"CreationDate" timestamp without time zone, 
		"UpdateDate" timestamp without time zone, 
		"DeletionDate" timestamp without time zone, 
		"CreationUserId" bigint, 
		"UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT     "DARJPaymentId",
		   "AccountId",
		   "OperationId",
		   "TaxId",
		   "ContributorTaxId",
		   "ReferenceNumber",
		   "PrincipalValue",
		   "FineValue",
		   "InterestValue",
		   "MonetaryValue",
		   "TotalValue",
		   "RateValue",
		   "DueDate",
		   "PaymentDate",
		   "CodeRevenue",
		   "StateRegistration",
		   "OriginDocument",
		   "RateValueType",
		   "Description",
		   "Identifier",
		   "Status",
		   "Attempts",
		   "ExternalIdentifier",
		   "CreationDate",
		   "UpdateDate",
		   "DeletionDate",
		   "CreationUserId",
		   "UpdateUserId"
   FROM 
		public."DARJPayment"
   WHERE 
		  "Status" = "paramStatus" AND
	  	  "DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getdarjpaymentbystatus(integer)
    OWNER TO "OSB";
