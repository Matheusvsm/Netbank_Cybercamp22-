
CREATE OR REPLACE FUNCTION public.getpixoutbyid(
	"paramPixOutId" bigint)
    RETURNS TABLE("PixOutId" bigint, "AccountId" bigint, "OperationId" bigint, "ToTaxId" text, "ToName" text, "ToBank" text, "ToBankBranch" text, "ToBankAccount" text, "ToBankAccountDigit" text, "Value" numeric, "PaymentDate" timestamp without time zone, "Identifier" text, "PixKey" text, "PixKeyType" integer, "AccountType" integer, "CustomerMessage" text, "Description" text, "Attempts" integer, "Status" integer, "ExternalIdentifier" bigint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint,  "ResponseMessage" text) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$

SELECT "PixOutId",
"AccountId",
"OperationId",
"ToTaxId",
"ToName",
"ToBank",
"ToBankBranch",
"ToBankAccount",
"ToBankAccountDigit",
"Value",
"PaymentDate",
"Identifier",
"PixKey",
"PixKeyType",
"AccountType",
"CustomerMessage",
"Description",
"Attempts",
"Status",
"ExternalIdentifier",
"CreationDate",
"UpdateDate",
"DeletionDate",
"CreationUserId",
"UpdateUserId",
"ResponseMessage"
	FROM public."PixOut" 
	Where
		"PixOutId" = "paramPixOutId"
	AND 
		"DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getpixoutbyid(bigint)
    OWNER TO "OSB";