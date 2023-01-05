CREATE OR REPLACE FUNCTION public.getgarepaymentbyid(
	"paramGAREPaymentId" bigint
    )
    RETURNS TABLE("GAREPaymentId" bigint,
                  "AccountId" bigint,
                  "OperationId" bigint,
                  "TaxId" character varying,
                  "ContributorTaxId" character varying,
                  "ReferenceNumber" character varying,
                  "PrincipalValue" numeric,
                  "FineValue" numeric,
                  "InterestValue" numeric,
                  "TotalValue" numeric,
                  "RateValue" numeric,
                  "DueDate" timestamp without time zone,
                  "PaymentDate" timestamp without time zone,
                  "CodeRevenue" character varying,
                  "StateRegistration" character varying,
                  "ActiveDebit" character varying,
                  "QuoteNumberNotification" character varying,
                  "RateValueType" bigint,
                  "Description" character varying,
                  "Identifier" character varying,
                  "GAREType" integer,
                  "Attempts" integer,
                  "Status" integer,
                  "DeletionDate" timestamp without time zone,
                  "CreationDate" timestamp without time zone,
                  "UpdateDate" timestamp without time zone,
                  "CreationUserId" bigint,
                  "UpdateUserId" bigint
                  )
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT "GAREPaymentId",
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
        "RateValueType",
        "Description",
        "Identifier",
        "GAREType",
        "Attempts",
        "Status",
        "DeletionDate",
        "CreationDate",
        "UpdateDate",
        "CreationUserId",
        "UpdateUserId"

FROM public."GAREPayment"

WHERE 
    "GAREPaymentId" = "paramGAREPaymentId"
    AND "DeletionDate" IS NULL;

$BODY$;
ALTER FUNCTION public.getgarepaymentbyid(bigint)
    OWNER TO "OSB";