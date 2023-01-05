CREATE OR REPLACE FUNCTION public.insertgarepayment(
	"paramAccountId" bigint,
	"paramOperationId" bigint,
	"paramTaxId" character varying,
	"paramContributorTaxId" character varying,
	"paramReferenceNumber" character varying,
	"paramPrincipalValue" numeric,
	"paramFineValue" numeric,
	"paramInterestValue" numeric,
	"paramTotalValue" numeric,
	"paramRateValue" numeric,
	"paramDueDate" timestamp without time zone,
	"paramPaymentDate" timestamp without time zone,
	"paramCodeRevenue" character varying,
	"paramStateRegistration" character varying,
	"paramActiveDebit" character varying,
	"paramQuoteNumberNotification" character varying,
	"paramStatus" integer,
	"paramRateValueType" bigint,
	"paramDescription" character varying,
	"paramIdentifier" character varying,
	"paramGAREType" integer,
	"paramUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."GAREPayment"(
                    "AccountId",
					"OperationId",
					"TaxId",
					"ContributorTaxId",
					"ReferenceNumber",
					"PrincipalValue",
					"FineValue",
					"InterestValue",
					"TotalValue",
					"RateValue",
					"DueDate",
					"PaymentDate",
					"CodeRevenue",
					"StateRegistration",
					"ActiveDebit",
					"QuoteNumberNotification",
					"Status",
					"RateValueType",
					"Description",
					"Identifier",				
					"CreationDate",
					"UpdateDate",
					"GAREType",
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
					"paramTotalValue",
					"paramRateValue",
					"paramDueDate",
					"paramPaymentDate",
					"paramCodeRevenue",
					"paramStateRegistration",
					"paramActiveDebit",
					"paramQuoteNumberNotification",
					"paramStatus",
					"paramRateValueType",
					"paramDescription",
					"paramIdentifier",			
                    Now(),
					Now(),
					"paramGAREType",
					"paramUserId",
                    "paramUserId"
					)
$BODY$;

ALTER FUNCTION public.insertgarepayment(bigint, bigint, character varying, character varying, character varying, numeric, numeric, numeric, numeric, numeric, timestamp without time zone, timestamp without time zone, character varying, character varying, character varying, character varying, integer, bigint, character varying, character varying, integer, bigint)
    OWNER TO "OSB";
