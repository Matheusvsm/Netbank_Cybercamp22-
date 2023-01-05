DROP FUNCTION public.insertuserwebhook(bigint, character varying, character varying, character varying, character varying, character varying, character varying, integer, bigint, character varying, character varying, character varying, character varying);

CREATE OR REPLACE FUNCTION public.insertuserwebhook(
	"paramCompanyId" bigint,
	"paramTaxId" character varying,
	"paramName" character varying,
	"paramMail" character varying,
	"paramPhoneNumber" character varying,
	"paramAccountName" character varying,
	"paramAccountTaxId" character varying,
	"paramStatus" integer,
	"paramEventType" bigint,
	"paramUserTaxId" character varying,
	"paramAccountKey" character varying,
	"paramPassword" character varying,
    "paramSalt" character varying,
    "paramLockedUser" boolean
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."UserWebhook"
                    (
					 "CompanyId",
                     "TaxId",           
                     "Name",
                     "Mail",
                     "PhoneNumber",
                     "AccountName",
                     "AccountTaxId",
                     "Status",
                     "EventType",
                     "UserTaxId",
                     "AccountKey",
                     "Password",
                     "Salt",
                     "LockedUser",
                     "CreationDate",
                     "UpdateDate",
                     "CreationUserId",
                     "UpdateUserId")
             VALUES (
				 	"paramCompanyId",
                    "paramTaxId",
                    "paramName",
                    "paramMail",
                    "paramPhoneNumber",
                    "paramAccountName", 
                    "paramAccountTaxId",
                    "paramStatus", 
                    "paramEventType",
				 	"paramUserTaxId",
                    "paramAccountKey",
                    "paramPassword",
                    "paramSalt",
                    "paramLockedUser",
                     Now(),
                     Now(),
                     '0',
                     '0');
$BODY$;

ALTER FUNCTION public.insertuserwebhook(bigint, character varying, character varying, character varying, character varying, character varying, character varying, integer, bigint, character varying, character varying, character varying, character varying, boolean)
    OWNER TO "OSB";
