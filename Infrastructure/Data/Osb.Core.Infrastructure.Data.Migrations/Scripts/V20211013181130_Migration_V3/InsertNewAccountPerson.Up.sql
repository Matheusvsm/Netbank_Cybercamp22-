CREATE OR REPLACE FUNCTION public.insertnewaccountperson(
	"paramNewAccountId" bigint,
	"paramTaxId" character varying,
	"paramName" character varying,
	"paramMail" character varying,
	"paramOccupation" character varying,
	"paramPhone" character varying,
	"paramPersonRoleType" integer,
	"paramMotherFullName" character varying,
	"paramFatherFullName" character varying,
	"paramNationality" character varying,
	"paramBirthCity" character varying,
	"paramBirthState" character varying,
	"paramGender" integer,
	"paramMaritalStatus" integer,
	"paramSpouseName" character varying,
	"paramIdentityDocument" character varying,
	"paramCompanyType" integer,
	"paramCompanyActivity" character varying,
	"paramConstitutionDate" timestamp without time zone,
	"paramCheckPendingTransfers" boolean,
	"paramBirthDate" timestamp without time zone,
	"paramPersonName" character varying,
	"paramPhoneNumber" character varying,
	"paramNickname" character varying,
	"paramPubliclyExposedPerson" boolean,
    "paramUserId" bigint)
    RETURNS TABLE("NewAccountPersonId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."NewAccountPerson"
                    (
                    "NewAccountId",
                    "TaxId",
                    "Name",
                    "Mail",
                    "Occupation",
                    "Phone",
                    "PersonRoleType",
                    "MotherFullName",
                    "FatherFullName",
                    "Nationality",
                    "BirthCity",
                    "BirthState",
                    "Gender",
                    "MaritalStatus",
                    "SpouseName",
                    "IdentityDocument",
                    "CompanyType",
                    "CompanyActivity",
                    "ConstitutionDate",
                    "CheckPendingTransfers",
                    "BirthDate",
                    "PersonName",
                    "PhoneNumber",
                    "Nickname",
                    "PubliclyExposedPerson",
                    "CreationDate",
                    "UpdateDate",
                    "DeletionDate",
                    "CreationUserId",
                    "UpdateUserId"
                    )
	VALUES (
            "paramNewAccountId",
            "paramTaxId",
            "paramName",
            "paramMail",
            "paramOccupation",
            "paramPhone",
            "paramPersonRoleType",
            "paramMotherFullName",
            "paramFatherFullName",
            "paramNationality",
            "paramBirthCity",
            "paramBirthState",
            "paramGender",
            "paramMaritalStatus",
            "paramSpouseName",
            "paramIdentityDocument",
            "paramCompanyType",
            "paramCompanyActivity",
            "paramConstitutionDate",
            "paramCheckPendingTransfers",
            "paramBirthDate",
            "paramPersonName",
            "paramPhoneNumber",
            "paramNickname",
            "paramPubliclyExposedPerson",
            NOW(),
            NOW(),
            NULL,
            "paramUserId",
            "paramUserId"
           ) RETURNING "NewAccountPersonId";
$BODY$;

ALTER FUNCTION public.insertnewaccountperson(bigint, character varying, character varying, character varying, character varying, character varying, integer, character varying, character varying, character varying, character varying, character varying, integer, integer, character varying, character varying, integer, character varying, timestamp without time zone, boolean, timestamp without time zone, character varying, character varying, character varying, boolean, bigint)
    OWNER TO "OSB";
