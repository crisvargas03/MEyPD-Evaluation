export const GetPresentStudentsToday = async () => {
  const url = process.env.REACT_APP_API_URL + `api/Attendance/today`;

  const resp = await fetch(url);
  const data = await resp.json();
  return await data;
};
