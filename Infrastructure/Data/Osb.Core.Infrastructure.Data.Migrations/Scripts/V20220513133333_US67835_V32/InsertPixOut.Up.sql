CREATE FUNCTION public.insertpixout(
    "paramAccountId" bigint,
    "paramOperationId" bigint,
    "paramToName" character varying,
    "paramToTaxId" character varying,
    "paramToBank" character varying,
    "paramToBankBranch" character varying,
    "paramToBankAccount" character varying,
    "paramToBankAccountDigit" character varying,
    "paramValue" decimal,
    "paramStatus" integer,
    "paramPaymentDate" timestamp without time zone,
    "paramIdentifier" character varying,
    "paramCustomerMessage" character varying,
    "paramPixKey" character varying,
    "paramPixKeyType" integer,
    "paramAccountType" integer,
    "paramDescription" character varying,
    "paramUserId" bigint
 )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE 
AS $BODY$
INSERT INTO public."PixOut"
                    (
                    "AccountId",
                    "OperationId",
                    "ToName",
                    "ToTaxId",
                    "ToBank",
                    "ToBankBranch",
                    "ToBankAccount",
                    "ToBankAccountDigit",
                    "Value",
                    "Status",
                    "PaymentDate",
                    "Identifier",
                    "CustomerMessage",
                    "PixKey",
                    "PixKeyType",
                    "AccountType",
                    "Description",
                    "CreationDate",
                    "UpdateDate",
                    "DeletionDate",
                    "CreationUserId",
                    "UpdateUserId"
                    )
    VALUES (
        "paramAccountId",
        "paramOperationId",
        "paramToName",
        "paramToTaxId",
        "paramToBank",
        "paramToBankBranch",
        "paramToBankAccount",
        "paramToBankAccountDigit",
        "paramValue",
        "paramStatus",
        "paramPaymentDate",
        "paramIdentifier",
        "paramCustomerMessage",
        "paramPixKey",
        "paramPixKeyType",
        "paramAccountType",
        "paramDescription",
        now(),
        now(),
        NULL,
        "paramUserId",
        "paramUserId"
    )
$BODY$;

ALTER FUNCTION public.insertpixout(bigint, bigint, character varying, character varying, character varying, character varying, character varying, character varying, decimal, integer, timestamp without time zone, character varying, character varying, character varying, integer, integer, character varying, bigint) 
    OWNER TO "OSB";