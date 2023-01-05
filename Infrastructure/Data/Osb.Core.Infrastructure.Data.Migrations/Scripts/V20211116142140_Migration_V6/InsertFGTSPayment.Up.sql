CREATE OR REPLACE FUNCTION public.insertfgtspayment(
	"paramAccountId" bigint,
    "paramOperationId" bigint,
	"paramTaxId" character varying,
	"paramContributorTaxId" character varying,
	"paramPrincipalValue" numeric,
	"paramCodeRevenue" character varying,
	"paramBarcode" character varying,
	"paramFGTSIdentifier" character varying,
	"paramSocialConnectivityCode" bigint,
	"paramSocialConnectivityDigit" integer,
	"paramPaymentDate" timestamp without time zone,
	"paramRateValueType" bigint,
	"paramStatus" integer,
	"paramDescription" character varying,
	"paramIdentifier" character varying,
	"paramUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."FGTSPayment"
                    (
                     "AccountId",
                     "OperationId",
                     "TaxId",
                     "ContributorTaxId",
                     "PrincipalValue",
                     "CodeRevenue",
                     "Barcode",
                     "FGTSIdentifier",
                     "SocialConnectivityCode",
                     "SocialConnectivityDigit",
                     "PaymentDate",
                     "RateValueType",
					 "Status",
                     "Description",
                     "Identifier",
                     "CreationDate",
                     "UpdateDate",
					 "CreationUserId",
                     "UpdateUserId")
             VALUES (
                    "paramAccountId",
                    "paramOperationId",
                    "paramTaxId" ,
                    "paramContributorTaxId",
                    "paramPrincipalValue",
                    "paramCodeRevenue",
                    "paramBarcode",
                    "paramFGTSIdentifier",
                    "paramSocialConnectivityCode",
                    "paramSocialConnectivityDigit",
                    "paramPaymentDate",
                    "paramRateValueType",
                    "paramStatus",
                    "paramDescription",
                    "paramIdentifier",
                    NOW(),
                    NOW(),
                    "paramUserId",
                    "paramUserId")
$BODY$;

ALTER FUNCTION public.insertfgtspayment(bigint, bigint, character varying, character varying, numeric, character varying, character varying, character varying, bigint, integer, timestamp without time zone, bigint, integer, character varying, character varying,bigint)    
    OWNER TO "OSB";