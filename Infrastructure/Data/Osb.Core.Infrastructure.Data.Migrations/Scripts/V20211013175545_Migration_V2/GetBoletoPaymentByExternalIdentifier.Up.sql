CREATE OR REPLACE FUNCTION public.getboletopaymentbyexternalidentifier(
	"paramExternalIdentifier" bigint)
    RETURNS TABLE(
                "BoletoPaymentId" bigint,                 
                "AccountId" bigint,
                "Name" character varying, 
                "TaxId" character varying,
                "ReceiverName" character varying, 
                "ReceiverTaxId" character varying,
                "PayerName" character varying, 
                "PayerTaxId" character varying, 
                "OperationId" bigint,
                "Status" integer,
                "Barcode" character varying, 
                "PaymentValue" numeric, 
                "PaymentDate" timestamp without time zone, 
                "DueDate" timestamp without time zone,
                "DiscountValue" numeric,
                "Description" character varying, 
                "Attempts" integer, 
                "Identifier" character varying, 
                "ExternalIdentifier" character varying,
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
SELECT "BoletoPaymentId",        
        "AccountId",
        "Name",
        "TaxId",
        "ReceiverName",
        "ReceiverTaxId",
        "PayerName",
        "PayerTaxId",
        "OperationId",
        "Status",
        "Barcode",
        "PaymentValue",
        "PaymentDate",
        "DueDate",
        "DiscountValue",
        "Description",
        "Attempts",
        "Identifier",
        "ExternalIdentifier",
        "DeletionDate",
        "CreationDate",
        "UpdateDate",
        "CreationUserId",
        "UpdateUserId"
FROM public."BoletoPayment"
WHERE "ExternalIdentifier" = "paramExternalIdentifier"
AND "DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getboletopaymentbyexternalidentifier(bigint)
    OWNER TO "OSB";
