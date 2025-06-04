import { SearchOff } from "@mui/icons-material";
import { Button, Paper, Typography } from "@mui/material";
import { Link } from "react-router-dom";

const NotFound = () => {
  return (
    <Paper
      sx={{
        height: 400,
        display: "flex",
        flexDirection: "column",
        justifyContent: "center",
        alignItems: "center",
        p: 6,
      }}
    >
      <SearchOff sx={{ fontSize: 100 }} color="primary"></SearchOff>
      <Typography variant="h3" gutterBottom>
        Oops - we could not find what you are looking for
      </Typography>
      <Button fullWidth component={Link} to="/catalog">
        Go back to the store
      </Button>
    </Paper>
  );
};

export default NotFound;
