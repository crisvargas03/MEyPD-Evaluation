export const GetByTeacher = async (teacherId) => {
  const url =
    process.env.REACT_APP_API_URL + `api/Student/by_teacher/${teacherId}`;

  const resp = await fetch(url);
  const data = await resp.json();
  return await data;
};
