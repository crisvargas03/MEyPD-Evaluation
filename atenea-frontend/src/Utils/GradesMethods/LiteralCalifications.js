export const LiteralCalifications = (calification) => {
  if (calification >= 0 && calification <= 69) {
    return "F";
  } else {
    if (calification >= 70 && calification <= 79) {
      return "C";
    } else {
      if (calification >= 80 && calification <= 89) {
        return "B";
      } else {
        if (calification >= 90 && calification <= 100) {
          return "A";
        }
      }
    }
  }
};
