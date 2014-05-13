// Copyright 2014 Toggl Desktop developers.

#ifndef SRC_TIME_ENTRY_H_
#define SRC_TIME_ENTRY_H_

#include <string>
#include <vector>

#include "./types.h"
#include "./base_model.h"

#include "Poco/Types.h"

namespace kopsik {

class TimeEntry : public BaseModel {
 public:
    TimeEntry()
        : BaseModel()
    , wid_(0)
    , pid_(0)
    , tid_(0)
    , billable_(false)
    , start_(0)
    , stop_(0)
    , duration_in_seconds_(0)
    , description_("")
    , duronly_(false)
    , created_with_("")
    , project_guid_("")
    , project_and_task_label_("")
    , color_code_("")
    , date_duration_("")
    , start_time_string_("")
    , end_time_string_("") {}

    virtual ~TimeEntry() {}

    std::vector<std::string> TagNames;

    std::string Tags() const;
    void SetTags(const std::string tags);

    Poco::UInt64 WID() const {
        return wid_;
    }
    void SetWID(const Poco::UInt64 value);

    Poco::UInt64 PID() const {
        return pid_;
    }
    void SetPID(const Poco::UInt64 value);

    Poco::UInt64 TID() const {
        return tid_;
    }
    void SetTID(const Poco::UInt64 value);

    bool Billable() const {
        return billable_;
    }
    void SetBillable(const bool value);

    Poco::Int64 DurationInSeconds() const {
        return duration_in_seconds_;
    }
    void SetDurationInSeconds(const Poco::Int64 value);

    std::string DurationString() const;

    bool DurOnly() const {
        return duronly_;
    }
    void SetDurOnly(const bool value);

    std::string Description() const {
        return description_;
    }
    void SetDescription(const std::string value);

    std::string StartString() const;
    void SetStartString(const std::string value);

    Poco::UInt64 Start() const {
        return start_;
    }
    void SetStart(const Poco::UInt64 value);

    std::string DateHeaderString() const;

    std::string StopString() const;
    void SetStopString(const std::string value);

    Poco::UInt64 Stop() const {
        return stop_;
    }
    void SetStop(const Poco::UInt64 value);

    std::string CreatedWith() const {
        return created_with_;
    }
    void SetCreatedWith(const std::string value);

    void StopAt(const Poco::UInt64);

    std::string String() const;

    bool IsToday() const;

    std::string ProjectGUID() const {
        return project_guid_;
    }
    void SetProjectGUID(const std::string);

    std::string ModelName() const {
        return "time_entry";
    }
    std::string ModelURL() const {
        return "/api/v8/time_entries";
    }

    void LoadFromJSONNode(JSONNODE * const);
    JSONNODE *SaveToJSONNode() const;

    // User-triggered changes to timer:
    void SetDurationUserInput(const std::string);
    void SetStopUserInput(const std::string);
    void SetStartUserInput(const std::string);

    bool IsTracking() const {
        return duration_in_seconds_ < 0;
    }

    void StopTracking();

    virtual bool ResolveError(const kopsik::error err);

    // For displaying time entries, will not be saved etc
    void SetProjectAndTaskLabel(const std::string value) {
        project_and_task_label_ = value;
    }
    std::string ProjectAndTaskLabel() const {
        return project_and_task_label_;
    }

    // For displaying time entries, will not be saved etc
    void SetColorCode(const std::string value) {
        color_code_ = value;
    }
    std::string ColorCode() const {
        return color_code_;
    }

    // For displaying time entries, will not be saved etc
    void SetDateDuration(const std::string value) {
        date_duration_ = value;
    }
    std::string DateDuration() const {
        return date_duration_;
    }

    // For displaying time entries, will not be saved etc
    void SetStartTimeString(const std::string value) {
        start_time_string_ = value;
    }
    std::string StartTimeString() const {
        return start_time_string_;
    }

    // For displaying time entries, will not be saved etc
    void SetEndTimeString(const std::string value) {
        end_time_string_ = value;
    }
    std::string EndTimeString() const {
        return end_time_string_;
    }

 private:
    Poco::UInt64 wid_;
    Poco::UInt64 pid_;
    Poco::UInt64 tid_;
    bool billable_;
    Poco::UInt64 start_;
    Poco::UInt64 stop_;
    Poco::Int64 duration_in_seconds_;
    std::string description_;
    bool duronly_;
    std::string created_with_;
    std::string project_guid_;

    // For displaying time entries, will not be saved etc
    std::string project_and_task_label_;
    std::string color_code_;
    std::string date_duration_;
    std::string start_time_string_;
    std::string end_time_string_;

    bool setDurationStringHHMMSS(const std::string value);
    bool setDurationStringHHMM(const std::string value);
    bool setDurationStringMMSS(const std::string value);

    void loadTagsFromJSONNode(JSONNODE * const);

    bool durationTooLarge(const kopsik::error) const;
    bool stopTimeMustBeAfterStartTime(const kopsik::error err) const;
    bool userCannotAccessTheSelectedProject(const kopsik::error err) const;
    bool userCannotAccessSelectedTask(const kopsik::error err) const;
};

bool CompareTimeEntriesByStart(TimeEntry *a, TimeEntry *b);

}  // namespace kopsik

#endif  // SRC_TIME_ENTRY_H_
