export const SaveAttendance = async (attendance) => {
  const url = process.env.REACT_APP_API_URL + "api/Attendance";
  const methodPOST = {
    method: "POST",
    body: JSON.stringify(attendance),
    headers: {
      "Content-Type": "application/json",
    },
  };

  const resp = await fetch(url, methodPOST);
  const data = await resp.json();

  return await data;
};
