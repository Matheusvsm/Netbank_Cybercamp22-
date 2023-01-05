CREATE FUNCTION public.insertrefundpixin(
    "paramAccountId" bigint,
    "paramOperationId" bigint,
    "paramToTaxId" character varying,
    "paramToName" character varying,
    "paramToBank" character varying,
    "paramToBankBranch" character varying,
    "paramToBankAccount" character varying,
    "paramToBankAccountDigit" character varying,
    "paramRefundValue" numeric,
    "paramCustomerMessage" character varying,
    "paramDocumentNumber" bigint,
    "paramIdentifier" character varying,
    "paramStatus" integer,
    "paramUserId" bigint
 )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE 
AS $BODY$
INSERT INTO public."RefundPixIn"
                    (
                    "AccountId",
                    "OperationId",
                    "ToTaxId",
                    "ToName",
                    "ToBank",
                    "ToBankBranch",
                    "ToBankAccount",
                    "ToBankAccountDigit",
                    "RefundValue",
                    "CustomerMessage",
                    "DocumentNumber",
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
        "paramToTaxId",
        "paramToName",
        "paramToBank",
        "paramToBankBranch",
        "paramToBankAccount",
        "paramToBankAccountDigit",
        "paramRefundValue",
        "paramCustomerMessage",
        "paramDocumentNumber",
        "paramIdentifier",
        "paramStatus",
        now(),
        now(),
        "paramUserId",
        "paramUserId"
    )
$BODY$;

ALTER FUNCTION public.insertrefundpixin( bigint, bigint, character varying, character varying, character varying, character varying, character varying, character varying, numeric, character varying, bigint, character varying, integer, bigint) 
    OWNER TO "OSB";