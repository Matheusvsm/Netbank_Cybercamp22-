CREATE OR REPLACE FUNCTION public.insertlimitedaccount(
	"paramCompanyId" bigint,
	"paramName" character varying,
	"paramPhoneNumber" character varying,
	"paramTaxId" character varying,
	"paramMail" character varying,
	"paramNickname" character varying,
	"paramBank" character varying,
	"paramBankBranch" character varying,
	"paramBankAccount" character varying,
	"paramBankAccountDigit" character varying,
	"paramBirthDate" timestamp without time zone,
	"paramTradingName" character varying,
	"paramLegalName" character varying,
	"paramConstitutionDate" timestamp without time zone,
    "paramPassword" character varying,
    "paramSalt" character varying,
	"paramStatus" integer,
    "paramUserId" bigint)
    RETURNS TABLE("LimitedAccountId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."LimitedAccount"
                    (
                    "CompanyId",
                    "Name",
                    "PhoneNumber",
                    "TaxId",
                    "Mail",
                    "Nickname",
                    "Bank",
                    "BankBranch",
                    "BankAccount",
                    "BankAccountDigit",
                    "BirthDate",
                    "TradingName",
                    "LegalName",
                    "ConstitutionDate",
                    "Password",
                    "Salt",
                    "Status",
                    "CreationDate",
                    "UpdateDate",
                    "DeletionDate",
                    "CreationUserId",
                    "UpdateUserId" 
                    )
	VALUES (
            "paramCompanyId",
            "paramName",
            "paramPhoneNumber",
            "paramTaxId",
            "paramMail",
            "paramNickname",
            "paramBank",
            "paramBankBranch",
            "paramBankAccount",
            "paramBankAccountDigit",
            "paramBirthDate",
            "paramTradingName",
            "paramLegalName",
            "paramConstitutionDate",
            "paramPassword",
            "paramSalt",
            "paramStatus",
            NOW(),
            NOW(),
            NULL,
            "paramUserId",
            "paramUserId"
           ) RETURNING "LimitedAccountId";
$BODY$;

ALTER FUNCTION public.insertlimitedaccount(bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, timestamp without time zone, character varying, character varying, timestamp without time zone, character varying, character varying, integer, bigint)
    OWNER TO "OSB";