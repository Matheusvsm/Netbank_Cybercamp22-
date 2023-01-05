DROP FUNCTION public.insertuserinformation(
    bigint, 
    character varying,
    character varying,
	character varying,
	character varying,
	character varying,
	character varying,
	character varying,
	character varying,
	character varying,
	character varying
);

CREATE FUNCTION public.insertuserinformation(
    "paramUserId" bigint,
	"paramName" character varying,
	"paramMail" character varying,
	"paramPhoneNumber" character varying,
	"paramZipCode" character varying,
	"paramStreet" character varying,
	"paramNumber" character varying,
	"paramReference" character varying,
	"paramDistrict" character varying,
	"paramComplement" character varying,
	"paramCity" character varying,
	"paramState" character varying,
	"paramCountry" character varying
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."UserInformation"(
	 "UserId", "Name", "Mail", "PhoneNumber", "ZipCode", "Street", "Number", "Reference" , "District", "Complement", "City", "State", "Country", "CreationUserId", "UpdateUserId", "CreationDate", "UpdateDate")
	VALUES (
        "paramUserId",
		"paramName",
        "paramMail",
        "paramPhoneNumber",
        "paramZipCode",
        "paramStreet",
        "paramNumber",
        "paramReference",
        "paramDistrict",
        "paramComplement",
        "paramCity",
        "paramState",
        "paramCountry",
        "paramUserId",
        "paramUserId",
        now(),
		now()
	);
$BODY$;

ALTER FUNCTION public.insertuserinformation(bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying)
    OWNER TO "OSB";
