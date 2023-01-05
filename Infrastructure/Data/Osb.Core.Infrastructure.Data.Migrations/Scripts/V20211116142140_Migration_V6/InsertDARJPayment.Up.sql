CREATE OR REPLACE FUNCTION public.insertdarjpayment(
	"paramAccountId" bigint,
	"paramOperationId" bigint,
	"paramTaxId" character varying,
	"paramContributorTaxId" character varying,
	"paramReferenceNumber" character varying,
	"paramPrincipalValue" numeric,
	"paramFineValue" numeric,
	"paramInterestValue" numeric,
	"paramMonetaryValue" numeric,
	"paramTotalValue" numeric,
	"paramRateValue" numeric,
	"paramDueDate" timestamp without time zone,
	"paramCodeRevenue" character varying,
	"paramStateRegistration" character varying,
	"paramOriginDocument" bigint,
	"paramPaymentDate" timestamp without time zone,
	"paramRateValueType" bigint,
	"paramDescription" character varying,
	"paramIdentifier" character varying,
	"paramStatus" integer,
	"paramUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."DARJPayment"
                    (
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
					"CodeRevenue",  
					"StateRegistration",
					"OriginDocument", 
					"PaymentDate", 
					"RateValueType", 
					"Description", 
					"Identifier", 
					"Status",
					"CreationDate",
					"UpdateDate",
					"CreationUserId",
					"UpdateUserId"
                     )
    VALUES (
            "paramAccountId",
			"paramOperationId",
			"paramTaxId",
			"paramContributorTaxId",
			"paramReferenceNumber",
			"paramPrincipalValue",
			"paramFineValue",
			"paramInterestValue", 
			"paramMonetaryValue", 
			"paramTotalValue", 
			"paramRateValue", 
			"paramDueDate", 
			"paramCodeRevenue",  
			"paramStateRegistration",
			"paramOriginDocument", 
			"paramPaymentDate", 
			"paramRateValueType", 
			"paramDescription", 
			"paramIdentifier", 
			"paramStatus", 
	        now(),
		    now(),
		    "paramUserId",
	        "paramUserId"
		)
$BODY$;

ALTER FUNCTION public.insertdarjpayment(bigint, bigint, character varying, character varying, character varying, numeric, numeric, numeric, numeric, numeric, numeric, timestamp without time zone, character varying, character varying, bigint, timestamp without time zone, bigint, character varying, character varying, integer, bigint)
    OWNER TO "OSB";
