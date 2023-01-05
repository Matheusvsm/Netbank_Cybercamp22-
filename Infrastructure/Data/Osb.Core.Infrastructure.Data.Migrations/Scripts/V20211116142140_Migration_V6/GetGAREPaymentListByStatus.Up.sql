CREATE OR REPLACE FUNCTION public.getgarepaymentlistbystatus(
	"paramStatus" integer
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
                  "RateValueType" bigint,
                  "DueDate" timestamp without time zone,
                  "PaymentDate" timestamp without time zone,
                  "CodeRevenue" character varying,
                  "StateRegistration" character varying,
                  "ActiveDebit" character varying,
                  "QuoteNumberNotification" character varying,
                  "Description" character varying,
                  "Identifier" character varying,
                  "GAREType" integer,
                  "Status" integer,
                  "Attempts" integer,
                  "ExternalIdentifier" bigint,
                  "CreationDate" timestamp without time zone,
                  "UpdateDate" timestamp without time zone,
                  "DeletionDate" timestamp without time zone,
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
        "RateValueType",
        "DueDate",
        "PaymentDate",
        "CodeRevenue",
        "StateRegistration",
        "ActiveDebit",
        "QuoteNumberNotification",
        "Description",
        "Identifier",
        "GAREType",
        "Status",
        "Attempts",
        "ExternalIdentifier",
        "CreationDate",
        "UpdateDate",
        "DeletionDate",
        "CreationUserId",
        "UpdateUserId"

FROM public."GAREPayment"
WHERE 
    "Status" = "paramStatus"
    AND "DeletionDate" IS NULL;

$BODY$;
ALTER FUNCTION public.getgarepaymentlistbystatus(integer)
    OWNER TO "OSB";