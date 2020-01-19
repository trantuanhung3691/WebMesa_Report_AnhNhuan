function AskBeforeDelete(s) {
    var checkstr = confirm('Are you sure you want to delete this record?');
    if (checkstr == true) {
        return true;
    } else {
        return false;
    }
}
