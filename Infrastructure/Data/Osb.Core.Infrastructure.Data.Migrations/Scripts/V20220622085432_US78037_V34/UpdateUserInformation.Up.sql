DROP FUNCTION public.updateuserinformation(
    bigint, 
    text,
    text,
	text,
	text,
	text,
	text,
	text,
	text
);

CREATE FUNCTION public.updateuserinformation(
	"paramUserId" bigint,
	"paramName" text,
	"paramMail" text,	
	"paramPhoneNumber" text,
	"paramZipCode" text,
	"paramStreet" text,
	"paramNumber" text,
	"paramReference" text,
	"paramDistrict" text,
	"paramComplement" text,
	"paramCity" text,
	"paramState" text,
	"paramCountry" text
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."UserInformation"
SET "Name" = "paramName", 
	"Mail" = "paramMail",
	"PhoneNumber" = "paramPhoneNumber",
	"ZipCode" = "paramZipCode",
	"Street" = "paramStreet",
	"Number" = "paramNumber",
	"Reference" = "paramReference",
	"District" = "paramDistrict",
	"Complement" = "paramComplement",
	"City" = "paramCity",
	"State" = "paramState",
	"Country" = "paramCountry",
	"UpdateUserId" = "paramUserId",
	"UpdateDate" = now()
WHERE "UserId" = "paramUserId";
$BODY$;

ALTER FUNCTION public.updateuserinformation(bigint, text, text, text, text, text, text, text, text, text, text, text, text)
    OWNER TO "OSB";
